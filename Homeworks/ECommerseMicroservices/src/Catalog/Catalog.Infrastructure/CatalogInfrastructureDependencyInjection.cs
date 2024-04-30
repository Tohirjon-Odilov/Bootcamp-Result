using Catalog.Application.Abstractions;
using Catalog.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure
{
    public static class CatalogInfrastructureDependencyInjection
    {
        public static IServiceCollection AddCatalogInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ICatalogDbContext, CatalogDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("CatalogConnectionString"));
            });

            return services;
        }
    }
}
