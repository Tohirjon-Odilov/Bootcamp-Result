using JWT.Intro.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JWT.Intro.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
