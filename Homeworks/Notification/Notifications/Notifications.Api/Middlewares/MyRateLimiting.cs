namespace Notifications.Api.Middlewares
{
    public class MyRateLimiting
    {
        private int requestLimit;
        private readonly RequestDelegate next;
        private DateTime resetTime;

        public MyRateLimiting(RequestDelegate next)
        {
            requestLimit = 0;
            this.next = next;
            resetTime = DateTime.UtcNow.AddSeconds(20);
        }



        public async Task InvokeAsync(HttpContext context)
        {
            var currentTime = DateTime.UtcNow;

            if (currentTime >= resetTime && requestLimit != 0)
            {
                requestLimit = 0;
                resetTime = currentTime.AddSeconds(20);
            }

            if (requestLimit < 5)
            {
                requestLimit++;
                await next(context);
            } else
            {
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await context.Response.WriteAsync("Rate limit exceeded. Try again later.");
                return;
            }
        }
    }
}
