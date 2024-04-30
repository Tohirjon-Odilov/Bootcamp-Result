using Catalog.App.Abstraction;
using Catalog.App.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infra
{
    public static class CatalogInfrastuctureDependencyInjection
    {
        public static IServiceCollection AddCatalogInfrastuctureDependencyInjection
            (this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ICatalogDbContext, CatalogDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("CatalogConnectionString"));
            });

            return services;
        }
    }
}
