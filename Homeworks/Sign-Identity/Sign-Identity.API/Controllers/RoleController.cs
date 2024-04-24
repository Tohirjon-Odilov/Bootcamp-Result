using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sign_Identity.API.Filters;
using Sign_Identity.Domain.DTOs;

namespace Sign_Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDTO>> CreateRole(RoleDTO role)
        {

            var result = await _roleManager.FindByNameAsync(role.RoleName);

            if (result == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(role.RoleName));

                return Ok(new ResponseDTO
                {
                    Message = "Role Created",
                    IsSuccess = true,
                    StatusCode = 201
                });
            }

            return Ok(new ResponseDTO
            {
                Message = "Role cann not created",
                StatusCode = 403
            });
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<IdentityRole>>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(roles);
        }

        [HttpGet("{roleName}")]
        public async Task<IActionResult> GetRoleById(string  roleName)
        {
            var res = await _roleManager.FindByNameAsync(roleName);
            if (res is null)
                throw new Exception("Not found");

            return Ok(res);
        }

        [HttpDelete("{roleName}")]
        [Authorize(Roles = "Admin")]
        [AnyEndPointFilter]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var res = await _roleManager.FindByNameAsync(roleName);
            if (res is null)
                throw new Exception("Not found");

            var deletedRole = await _roleManager.DeleteAsync(res);
            if (!deletedRole.Succeeded)
                throw new Exception("Something went wrong");

            return Ok(deletedRole);
        }

        [HttpPut("{roleName}")]
        [Authorize(Roles = "Admin")]
        [AnyExceptionFilter]
        public async Task<IActionResult> UpdateRole(string roleName, string updateToRoleName)
        {
            var res = await _roleManager.FindByNameAsync(roleName);
            if (res is null)
                throw new Exception("Not found");
            res.Name = updateToRoleName;
            res.NormalizedName = updateToRoleName.ToUpper();

            var updatedRole = await _roleManager.UpdateAsync(res);
            if (!updatedRole.Succeeded)
                throw new Exception("Something went wrong!");
            return Ok();
        }

    }
}
