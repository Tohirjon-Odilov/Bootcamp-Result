using Cart.Application.Abstractions;
using Cart.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cart.Infrastructure
{
    public static class CartDependencyInjection
    {
        public static IServiceCollection AddCartDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, CartDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseNpgsql(configuration.GetConnectionString(""));
            });
            return services;
        }
    }
}
