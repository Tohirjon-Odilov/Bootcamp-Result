using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Abstraction;
using Ordering.Infrastructure.Persistance;

namespace Ordering.Infrastructure
{
    public static class OrderingDependencyInjection
    {
        public static IServiceCollection AddOrderingInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IOrderingDbContext,OrderingDbContext>(options =>
            {
                options.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"]);
            });

            return services;
        }
    }
}
