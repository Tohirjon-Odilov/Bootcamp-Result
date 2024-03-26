using GPSTracker.API.Application.DataTransferObjects.Auth;
using GPSTracker.API.Application.Services.AuthServices;
using GPSTracker.API.Application.Services.JWTServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GPSTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJWTService _jwtService;

        public AuthController(IAuthService authService, IJWTService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            return Ok(await _authService.Login(loginDTO));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddNewUser(RegisterDTO registerDTO)
        {
            return Ok(await _authService.Register(registerDTO));
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(TokenDTO tokenDTO)
        {
            return Ok(await _jwtService.RefreshTokenAsync(tokenDTO));
        }
    }
}
