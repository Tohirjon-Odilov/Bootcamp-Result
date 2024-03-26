using GPSTracker.API.Application.DataTransferObjects.Auth;
using GPSTracker.API.Domain.Entities.Auth;

namespace GPSTracker.API.Application.Services.JWTServices
{
    public interface IJWTService
    {
        TokenDTO GenerateToken(User user);
        ValueTask<TokenDTO> RefreshTokenAsync(TokenDTO tokenDTO);
    }
}
