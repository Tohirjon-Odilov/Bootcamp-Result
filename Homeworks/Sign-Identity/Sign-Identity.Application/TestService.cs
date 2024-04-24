using Microsoft.Extensions.DependencyInjection;
using Sign_Identity.Application.Services.AuthServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sign_Identity.Application
{
    public static class TestService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService,AuthService>();

            return services;
        }
    }
}
