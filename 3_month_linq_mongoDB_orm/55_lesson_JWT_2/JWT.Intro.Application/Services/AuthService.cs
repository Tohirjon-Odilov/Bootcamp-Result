using JWT.Intro.Domain.Entities.Models.AuthModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.Intro.Application.Services
{
    public class AuthService : IAuthService
    {
        public IConfiguration _configuration { get; set; }

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(User user)
        {
            if (user == null)
            {
                return "User Will be Null";
            }

            if (UserExist(user))
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("UserName", user.UserName),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("CreatedDate", DateTime.UtcNow.ToString()),
                    //new Claim("Permissions", jsonContent)
                };
                return await GenerateToken(claims);
            }
            return "User UnAuthorithe 401";
        }

        public async Task<string> GenerateToken(List<Claim> additionalClaims)
        {
            SymmetricSecurityKey? securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            SigningCredentials? credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            int expires = Convert.ToInt32(_configuration["JWT:ExpireDate"] ?? "10");

            List<Claim>? claims = new List<Claim>
            {
                // json token it
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                // Token boshlangan vaqti Iat
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);


            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,

                // token tugash vaqti vaqti
                expires: DateTime.UtcNow.AddMinutes(expires),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool UserExist(User user)
        {
            var login = "admin";
            var password = "123";

            if (user.Login == login && user.Password == password)
            {
                return true;
            }

            return false;
        }
    }
}
