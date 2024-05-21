using IdentityLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalBrand.Domain.Entities.Auth;
using PersonalBrand.Domain.IdentityModels;

namespace IdentityLayer.cs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(UserManager<UserModel> userManager, IConfiguration configuration) : ControllerBase
    {
        private readonly UserManager<UserModel> _userManager = userManager;
        private readonly IConfiguration _configuration = configuration;

        [HttpPost]
        public async Task<IActionResult> Register(Register registerModel)
        {
            return Ok(registerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
            {
                throw new ApplicationException();
            }

            if (!await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                throw new Exception();
            }
            var token = await user.GenerateToken(_configuration, _userManager);
            return Ok(token);
        }
    }
}
