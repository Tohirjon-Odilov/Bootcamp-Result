using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;

namespace FutureProjects.Application.Abstractions.IServices
{
    public interface IAuthService
    {
        public Task<ResponseLogin> GenerateToken(RequestLogin user);
    }
}
