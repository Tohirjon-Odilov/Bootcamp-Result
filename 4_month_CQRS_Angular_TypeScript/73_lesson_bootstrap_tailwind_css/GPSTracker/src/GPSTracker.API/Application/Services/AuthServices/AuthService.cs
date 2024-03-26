using GPSTracker.API.Application.DataTransferObjects.Auth;
using GPSTracker.API.Application.Services.Helpers;
using GPSTracker.API.Application.Services.JWTServices;
using GPSTracker.API.Domain.Entities.Auth;
using GPSTracker.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GPSTracker.API.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJWTService _jwtService;

        public AuthService(AppDbContext context, IPasswordHasher passwordHasher, IJWTService jwtService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async ValueTask<TokenDTO> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(user => user.UserName == loginDTO.UserName);

            if (user == null)
                throw new Exception("User not found");

            if (!_passwordHasher.Verify(user.PasswordHash, loginDTO.Password, user.Salt))
                throw new Exception("Username or password is not valid");

            return _jwtService.GenerateToken(user);
        }

        public async ValueTask<User> Register(RegisterDTO registerDTO)
        {
            var salt = Guid.NewGuid().ToString();
            var passwordHash = _passwordHasher.Encrypt(registerDTO.Password, salt);

            var user = new User
            {
                UserName = registerDTO.UserName,
                PasswordHash = passwordHash,
                PhoneNumber = registerDTO.PhoneNumber,
                Salt = salt,
                RefreshToken = Guid.NewGuid().ToString(),
                ExpireDate = DateTime.Now.AddDays(7)
            };

            var entityEntry = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
