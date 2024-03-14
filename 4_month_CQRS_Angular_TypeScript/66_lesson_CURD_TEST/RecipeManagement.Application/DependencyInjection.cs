using Microsoft.Extensions.DependencyInjection;
using RecipeManagement.Application.Abstractions.IServices;
using RecipeManagement.Application.Services.AuthServices;
using RecipeManagement.Application.Services.RecipeServices;

namespace RecipeManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRecipeService, RecipeService>();

            return services;
        }
    }
}
