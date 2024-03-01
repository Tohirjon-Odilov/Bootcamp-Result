using FutureProjects.Application.Abstractions;
using FutureProjects.Infrastructure.BaseRepositories;
using FutureProjects.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FutureProjects.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<FutureProjectsDbContext>(options =>
            {
                options.UseNpgsql(conf.GetConnectionString("FutureProjectsConnectionString"));
            });


            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            return services;
        }
    }
}
