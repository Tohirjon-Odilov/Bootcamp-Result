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
        private int _permission;

        public HasPermissionAttribute(Permission permission)
        {
            _permission = (int)permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;

            var permissionIds = identity.FindFirst("Permissions")?.Value;

            bool result = JsonSerializer.Deserialize<List<int>>(permissionIds).Any(a => _permission == a);

            if (!result)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
