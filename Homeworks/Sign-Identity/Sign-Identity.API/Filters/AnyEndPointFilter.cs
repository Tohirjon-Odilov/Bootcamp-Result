using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace Sign_Identity.API.Filters
{
    public class AnyEndPointFilter : Attribute, IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {

            var request = context.HttpContext.Request;
            Console.WriteLine($"Request to endpoint {request.Path} received.");
            
            var userAgent = request.Headers["User-Agent"].ToString();
            if (userAgent.Contains("MSIE")) 
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.HttpContext.Response.WriteAsync("Unsupported Browser");
                return null;
            }

            await next(context);


            return null;
        }
    }
}
