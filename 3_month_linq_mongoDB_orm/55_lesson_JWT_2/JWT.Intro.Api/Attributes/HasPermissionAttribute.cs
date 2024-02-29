using JWT.Intro.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Text.Json;

namespace JWT.Intro.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Enum)]
    public class HasPermissionAttribute : Attribute, IAuthorizationFilter
    {
        private Permission _permission;

        public HasPermissionAttribute(Permission permission)
        {
            _permission = permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;

            var permissionIds = identity.FindFirst("PermissionIds").Value;

            //bool result = JsonSerializer.Deserialize<List<int>>(permissionIds).Any(a => _permissionId == x);

            //if (!result)
            //{
            //    context.Result = new ForbidResult();
            //    return;
            //}
        }
    }
}
