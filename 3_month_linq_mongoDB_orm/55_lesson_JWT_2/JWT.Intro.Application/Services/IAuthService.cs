using JWT.Intro.Domain.Entities.Models.AuthModels;

namespace JWT.Intro.Application.Services
{
    public interface IAuthService
    {
        public Task<string> GenerateToken(User user);
    }
}
