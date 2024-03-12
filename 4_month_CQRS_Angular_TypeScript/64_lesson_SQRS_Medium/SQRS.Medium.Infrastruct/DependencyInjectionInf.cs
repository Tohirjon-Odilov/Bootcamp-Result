using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQRS.Medium.Application.Abstractions;
using SQRS.Medium.Infrastruct.Persistance;

namespace SQRS.Medium.Infrastruct
{
    public static class DependencyInjectionInf
    {
        public static IServiceCollection AddInfrastruct(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MediumDbContext>(ops =>
            {
                ops.UseNpgsql(configuration.GetConnectionString("DefCon"));

            });

            services.AddScoped<IApplicationDbContext, MediumDbContext>();
            return services;

        }
    }
}
