using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sign_Identity.API.Filters
{
    public class DeleteActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Salom");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Cookies.TryGetValue("accessToken", out string token))
            {
                context.Result = new BadRequestResult();
                return;
            }

            if (token == null || token == "")
            {
                context.Result = new NotFoundResult();
                return;
            }
            return;
        }
    }
}
