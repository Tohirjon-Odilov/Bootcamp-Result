using IdentityAuthLesson.DTOs;
using IdentityAuthLesson.Models;

namespace IdentityAuthLesson.Services
{
    public interface IAuthService
    {
        public Task<AuthDTO> GenerateToken(AppUser user);
    }
}
