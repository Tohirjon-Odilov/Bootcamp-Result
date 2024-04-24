using Sign_Identity.Domain.DTOs;
using Sign_Identity.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sign_Identity.Application.Services.AuthServices
{
    public interface IAuthService
    {
        public Task<AuthDTO> GenerateToken(User user);
    }
}
