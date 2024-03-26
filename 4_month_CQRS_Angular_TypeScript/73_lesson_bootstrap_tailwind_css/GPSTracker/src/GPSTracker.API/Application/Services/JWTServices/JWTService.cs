using GPSTracker.API.Application.DataTransferObjects.Auth;
using GPSTracker.API.Domain.Entities.Auth;
using GPSTracker.API.Domain.Entities.Configurations;
using GPSTracker.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GPSTracker.API.Application.Services.JWTServices
{
    public class JWTService : IJWTService
    {
        private readonly AppDbContext _appDbContext;
        private readonly JWTConfiguration _configuration;

        public JWTService(IConfiguration configuration, AppDbContext appDbContext)
        {
            _configuration = configuration.GetSection("JWT").Get<JWTConfiguration>();
            _appDbContext = appDbContext;
        }

        public TokenDTO GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expireInMinutes = Convert.ToInt32(_configuration.ExpireInMinutes ?? "60");

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName.ToString()));

            var token = new JwtSecurityToken(
               issuer: _configuration.Issuer,
               audience: _configuration.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(expireInMinutes),
               signingCredentials: credentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenDTO
            {
                AccessToken = accessToken,
                RefreshToken = user.RefreshToken,
                ExpireDate = user.ExpireDate
            };
        }

        public async ValueTask<TokenDTO> RefreshTokenAsync(TokenDTO tokenDTO)
        {
            var claims = await GetClaimsFromExpiredTokenAsync(tokenDTO.AccessToken);
            var id = Convert.ToInt32(claims.FindFirst(ClaimTypes.NameIdentifier).Value);

            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user.RefreshToken != tokenDTO.RefreshToken)
                throw new Exception("Refresh token is not valid");

            if (user.ExpireDate <= DateTime.Now)
                throw new Exception("Refresh token has already been expired");

            //updating refresh token and expired date
            user.RefreshToken = Guid.NewGuid().ToString();
            user.ExpireDate = DateTime.Now.AddDays(7);

            await _appDbContext.SaveChangesAsync();

            return GenerateToken(user);
        }

        public async ValueTask<ClaimsPrincipal> GetClaimsFromExpiredTokenAsync(string token)
        {
            var validationParametrs = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = _configuration.Issuer,
                ValidateAudience = true,
                ValidAudience = _configuration.Audience,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key)),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var claimsPrincipal = tokenHandler.ValidateToken(token, validationParametrs, out SecurityToken securityToken);
            var jwtsecurityToken = securityToken as JwtSecurityToken;

            if (jwtsecurityToken == null)
                throw new Exception("Invalid token");

            return claimsPrincipal;
        }
    }
}
