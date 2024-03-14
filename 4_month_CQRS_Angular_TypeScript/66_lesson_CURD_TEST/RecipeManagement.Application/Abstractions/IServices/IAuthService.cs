using RecipeManagement.Domain.Entities.DTOs;

namespace RecipeManagement.Application.Abstractions.IServices
{
    public interface IAuthService
    {
        public Task<string> SignUpAsync(RegisterLogin user);
        public Task<string> LogInAsync(RequestLogin user);
        public Task<ResponseLogin> Verification(RequestLogin user, string code);
    }
}
