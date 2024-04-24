using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Sign_Identity.Application.Services.AuthServices;
using Sign_Identity.Domain.DTOs;
using Sign_Identity.Domain.Entities.Auth;
using Sign_Identity.API.Filters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sign_Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthService _authService;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IAuthService authService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            //check model
            if (!ModelState.IsValid)
            {
                throw new Exception("Validation error");
            }
            // cehck dto
            if (string.IsNullOrWhiteSpace(registerDTO.Email))
            {
                throw new Exception("Validation error");
            }
            if (string.IsNullOrWhiteSpace(registerDTO.Username))
            {
                throw new Exception("Validation error");
            }
            if (string.IsNullOrWhiteSpace(registerDTO.FirstName))
            {
                throw new Exception("Validation error");
            }
            if (string.IsNullOrWhiteSpace(registerDTO.LastName))
            {
                throw new Exception("Validation error");
            }

            var check = await _userManager.FindByEmailAsync(registerDTO.Email);

            if (check != null)
            {
                return BadRequest("You already registered");
            }

            //Mapping
            var user = new User()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Username,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Age = registerDTO.Age
            };

            //create user
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            foreach (var role in registerDTO.Roles)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            if (!result.Succeeded)
            {
                return BadRequest("Something went wrong in Create");
            }

            return Ok("Qilichdek Qilichbek");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Something went wrong");
            }

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);


            if (user is null)
                return NotFound("Email not found");

            if (user.IsDeleted == true)
                throw new Exception("Not found");

            //var result = await _signInManager.PasswordSignInAsync(user: user, password: loginDTO.Password, isPersistent: false, lockoutOnFailure: false);

            /* if (!result.Succeeded)
                 return Unauthorized("Something went wrong in Authorization");*/

            var tokenDTO = await _authService.GenerateToken(user);


            if (tokenDTO.IsSuccess == false || tokenDTO.Token == "" || tokenDTO.Token is null)
            {
                throw new Exception("Something went wrong!!");
            }

            HttpContext.Response.Cookies.Append("accessToken", tokenDTO.Token);

            return Ok(tokenDTO);

        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Teacher")]
        [AuthorizeFilter]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userManager.Users.Where(x=>x.IsDeleted == false).ToListAsync());
            }
            catch
            {
                return NotFound("Users are not found");
            }
        }

        [HttpGet("{accountId}")]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                var result = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);


                if (result is null)
                {
                    return NotFound("Not found");
                }
                if (result.IsDeleted == true)
                    throw new Exception("Not found");
                return Ok(result);
            }
            catch
            {
                return NotFound("User is not found");
            }
        }

        [HttpPost("Logout")]
        [Authorize(Roles = "Admin, Teacher, Student")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();

                HttpContext.Response.Cookies.Delete("accessToken");

                return Ok("Loged Out");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{accountId}")]
        [DeleteActionFilter]
        [MyResultFilter]
        public async Task<IActionResult> DeleteAccount(string accountId)
        {
            var user = await _userManager.FindByIdAsync(accountId);

            if (user is null)
                throw new Exception("Not found");

            if (user.IsDeleted == true)
                throw new Exception("Not found");
            //var deleteUser = await _userManager.DeleteAsync(user);
            user.IsDeleted = true;
            user.DeletedDate = DateTime.UtcNow;
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new Exception("No deleted");
            return Ok(result);
        }

        [HttpPut("{accountId}")]
        [UpdateResourceFilter]
        public async Task<IActionResult> UpdateAccount(string accountId, UpdateDTO userUpdate)
        {
            var user = await _userManager.FindByIdAsync(accountId);

            if (user is null)
                throw new Exception("Not found");

            if (user.IsDeleted == true)
                throw new Exception("Not found");

            user.FirstName = userUpdate.FirstName;
            user.LastName = userUpdate.LastName;
            user.Age = userUpdate.Age;
            user.ModifiedDate = DateTime.UtcNow;
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new Exception("No deleted");


            return Ok(result);

        }
    }
}
