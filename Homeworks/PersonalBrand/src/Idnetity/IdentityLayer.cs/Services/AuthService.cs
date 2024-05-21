using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PersonalBrand.Domain.Entities.Auth;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityLayer.Services
{
    public static class AuthService
    {
        public static async Task<string> GenerateToken(this UserModel user, IConfiguration _config, UserManager<UserModel> _userManager)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:Secret"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_config["JWTSettings:Expire"]!);

            var roles = await _userManager.GetRolesAsync(user);

            // Ensure there's at least one role assigned to the user
            if (roles == null || roles.Count == 0)
            {
                throw new InvalidOperationException("User has no roles assigned.");
            }

            var roleName = roles[0];

            List<Claim> claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                    new Claim("UserId",user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FirstName!),
                    new Claim("Role", roleName)
                };



            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JWTSettings:ValidIssuer"],
                audience: _config["JWTSettings:ValidAudence"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
