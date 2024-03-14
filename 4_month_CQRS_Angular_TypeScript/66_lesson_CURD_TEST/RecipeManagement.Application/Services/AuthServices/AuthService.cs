using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RecipeManagement.Application.Abstractions;
using RecipeManagement.Application.Abstractions.IServices;
using RecipeManagement.Domain.Entities.DTOs;
using RecipeManagement.Domain.Entities.Models;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RecipeManagement.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        public AuthService(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }

        public async Task<string> SignUpAsync(RegisterLogin user)
        {
            var storedEmail = await _userRepository.GetByAny(x => x.Email == user.Email);
            var storedLogin = await _userRepository.GetByAny(x => x.Login == user.Login);

            if (storedEmail != null)
            {
                return "You've already Signed Up!";
            }
            else if (storedLogin != null)
            {
                return "Please make unique Login!";
            }

            var newUser = new User()
            {
                Name = user.Name!,
                Email = user.Email!,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role.ToLower(),
            };

            await _userRepository.Create(newUser);

            return "You've Signed Up successfully! Please Login to get start!";
        }

        public async Task<string> LogInAsync(RequestLogin user)
        {
            var model = await _userRepository.GetByAny(x => x.Login == user.Login);

            if (model == null)
            {
                return "Please Sign Up first!";
            }

            else if (model.Password != user.Password)
            {
                return "Something is incorrect!";
            }

            Random random = new Random();
            string code = random.Next(10000, 99999).ToString();
            model.confirmationCode = code;

            await _userRepository.Update(model);

            //Email Logic
            var emailSettings = _config.GetSection("EmailSettings");
            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                Subject = "Unique Code",
                Body = code,
                IsBodyHtml = true,

            };
            mailMessage.To.Add(model.Email);

            using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]))
            {
                Port = Convert.ToInt32(emailSettings["MailPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                EnableSsl = true,
            };
            await smtpClient.SendMailAsync(mailMessage);
            //

            return "We've sent the code to your email! Please enter the code in the next label to login on our website...";
        }

        public async Task<ResponseLogin> Verification(RequestLogin user, string code)
        {
            var model = await _userRepository.GetByAny(x => x.Login == user.Login);

            if (model == null)
            {
                return new ResponseLogin()
                {
                    Token = "Please Sign Up first!"
                };
            }

            else if (model.Password != user.Password || model.confirmationCode != code)
            {
                return new ResponseLogin()
                {
                    Token = "Something is incorrect!"
                };
            }

            var permissions = new List<int>();

            if (model.Role == "user")
            {
                permissions = new List<int>() { 2, 3 };
            }

            else if (model.Role == "chef")
            {
                permissions = new List<int>() { 1, 2, 3, 4, 5 };
            }

            var jsonContent = JsonSerializer.Serialize(permissions);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, model.Role),
                new Claim("Login", model.Login),
                new Claim("UserID", model.Id.ToString()),
                new Claim("CreatedDate", DateTime.UtcNow.ToString()),
                new Claim("Permissions", jsonContent),
            };

            return await GenerateToken(claims);
        }

        public async Task<ResponseLogin> GenerateToken(IEnumerable<Claim> additionalClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exDate = Convert.ToInt32(_config["JWT:ExpireDate"] ?? "1");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);


            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(exDate),
                signingCredentials: credentials);

            return new ResponseLogin()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

    }
}
