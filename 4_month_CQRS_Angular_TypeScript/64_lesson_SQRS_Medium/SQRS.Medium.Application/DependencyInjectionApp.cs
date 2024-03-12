using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SQRS.Medium.Application.Abstractions;
using SQRS.Medium.Application.Mappers;
using SQRS.Medium.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SQRS.Medium.Application
{
    public static class DependencyInjectionApp
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            return services;
        }
    }
}
