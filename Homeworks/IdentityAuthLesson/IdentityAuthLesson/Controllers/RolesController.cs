using IdentityAuthLesson.DTOs;
using IdentityAuthLesson.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace IdentityAuthLesson.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> CreateRole(RoleDTO role)
        {
            
            IdentityRole? result = await _roleManager
                .FindByNameAsync(roleName: role.RoleName);
                
            if (result == null)
            {
                await _roleManager.CreateAsync(role: new IdentityRole(roleName: role.RoleName));

                return Ok(value: new ResponseDTO
                {
                    Message = "Role Created",
                    IsSuccess = true,
                    StatusCode = 201
                });
            }

            return Ok(value: new ResponseDTO
            {
                Message = "Role cann not created",
                StatusCode = 403
            });
        }


        [HttpGet]
        public async Task<ActionResult<List<IdentityRole>>> GetAllRoles()
        {
            List<IdentityRole>? roles = await _roleManager.Roles.ToListAsync();

            return Ok(value: roles);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateRole(Guid id, RoleDTO name)
        {
            IdentityRole? role = await _roleManager
                .FindByIdAsync(id.ToString());

            if (role is not null)
            {
                role.Name = name.RoleName;

                return Ok(role);
            }

            return Ok(false);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteRolesById(Guid id)
        {
            IdentityRole? role = await _roleManager
                .FindByIdAsync(roleId: id.ToString());

            if(role is not null)
            {
                IdentityResult? roles = await _roleManager.DeleteAsync(role);
                return Ok(value: roles.Succeeded);
            }

            return Ok(value: false);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteRolesByName(RoleDTO name)
        {
            IdentityRole? roleName = await _roleManager
                .FindByNameAsync(roleName: name.RoleName);

            if (roleName is not null)
            {
                IdentityResult? roles = await _roleManager.DeleteAsync(role: roleName);
                return Ok(value: roles.Succeeded);
            }

            return Ok(value: false);
        }
    }
}
