using JWT.Intro.Application.Services;
using JWT.Intro.Domain.Entities.Models.AuthModels;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Intro.Api.Controllers.AuthControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public IAuthService _authService { get; set; }

        public IdentityController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var result = _authService.GenerateToken(user);
            return Ok(result);
        }
    }
}
