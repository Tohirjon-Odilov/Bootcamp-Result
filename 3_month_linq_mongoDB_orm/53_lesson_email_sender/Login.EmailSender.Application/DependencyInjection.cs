using Login.EmailSender.Application.Services.EmailService;
using Microsoft.Extensions.DependencyInjection;

namespace Login.EmailSender.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            //services.AddScoped<ISignUpService, SignUpService>();
            //services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
