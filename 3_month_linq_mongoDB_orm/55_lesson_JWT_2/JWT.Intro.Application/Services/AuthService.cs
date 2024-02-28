using JWT.Intro.Domain.Entities.Models.AuthModels;
using Microsoft.Extensions.Configuration;

namespace JWT.Intro.Application.Services
{
    public class AuthService : IAuthService
    {
        public IConfiguration Configuration { get; set; }

        public AuthService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            if (user == null)
            {
                return "User Will be Null";
            }
            else if (user.Id != Guid.NewGuid())
            {
                return "User not found";
            }
            if (UserExist(user))
            {
                // logic
            }
            return "User UnAuthorithe 401";
        }

        public bool UserExist(User user)
        {
            var login = "samurai";
            var password = "123";

            if (login == user.Login && password == user.Password)
            {
                return true;
            }
            return false;
        }
    }
}
