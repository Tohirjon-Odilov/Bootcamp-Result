using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sign_Identity.Domain.Entities.Auth;
using Sign_Identity.Infrastructure.Persistance;
using System.Data;
using System;

namespace Sign_Identity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbContextOptions(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<SignIdentityDbContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                        .UseNpgsql(configuration.GetConnectionString("Con"));
            });

            return services;
        }
    }
}
