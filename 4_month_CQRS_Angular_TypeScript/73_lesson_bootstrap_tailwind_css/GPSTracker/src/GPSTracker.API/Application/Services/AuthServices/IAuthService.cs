using GPSTracker.API.Application.DataTransferObjects.Auth;
using GPSTracker.API.Domain.Entities.Auth;

namespace GPSTracker.API.Application.Services.AuthServices
{
    public interface IAuthService
    {
        ValueTask<User> Register(RegisterDTO registerDTO);
        ValueTask<TokenDTO> Login(LoginDTO loginDTO);
    }
}
