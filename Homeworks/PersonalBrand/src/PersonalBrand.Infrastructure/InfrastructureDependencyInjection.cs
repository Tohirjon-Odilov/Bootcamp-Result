using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalBrand.Application.Abstractions;
using PersonalBrand.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencyInjection(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<IApplicationDbContext, PersonalBrandDbContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                        .UseNpgsql(configuration.GetConnectionString("Def"));
            });

            return service;
        }
    }
}
