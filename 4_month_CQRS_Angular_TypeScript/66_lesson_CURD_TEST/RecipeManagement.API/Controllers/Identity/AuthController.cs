using Microsoft.AspNetCore.Mvc;
using RecipeManagement.Application.Abstractions.IServices;
using RecipeManagement.Domain.Entities.DTOs;

namespace RecipeManagement.API.Controllers.Identity
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> SignUp([FromForm] RegisterLogin user)
        {
            if (user.Password != user.confirmPassword)
            {
                return BadRequest("Passwords are not the same!");
            }

            var result = await _authService.SignUpAsync(user);
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromForm] RequestLogin model)
        {
            var result = await _authService.LogInAsync(model);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseLogin>> Verification([FromForm] RequestLogin model, string verificationCode)
        {
            var result = await _authService.Verification(model, verificationCode);

            return Ok(result);
        }
    }
}
