using PersonalBrand.Application;
using PersonalBrand.Infrastructure;

namespace PersonalBrand.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddApplicationDependencyInjection();
            builder.Services.AddInfrastructureDependencyInjection(builder.Configuration);

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

            app.UseCors(options =>
            {
                options.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin();
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
