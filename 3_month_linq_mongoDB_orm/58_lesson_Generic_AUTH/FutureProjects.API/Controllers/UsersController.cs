using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using FutureProjects.Domain.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutureProjects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
        {
            var result = await _userService.GetAll();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> CreateUser(UserDTO model)
        {
            var result = await _userService.Create(model);

            return Ok(result);
        }
    }
}
