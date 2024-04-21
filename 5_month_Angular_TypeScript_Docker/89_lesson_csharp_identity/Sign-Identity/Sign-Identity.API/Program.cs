
using Microsoft.AspNetCore.Identity;
using Sign_Identity.Domain.Entities.Auth;
using Sign_Identity.Infrastructure;
using Sign_Identity.Infrastructure.Persistance;

namespace Sign_Identity.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContextOptions(builder.Configuration);

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SignIdentityDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddCors(cors =>
            {
                cors.AddDefaultPolicy(policy =>
                {
                    policy
                        .AllowAnyHeader()
                            .AllowAnyOrigin()
                                .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
