using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramBotWithBackgroundService.Bot.Models;
using TelegramBotWithBackgroundService.Bot.Persistance;
using TelegramBotWithBackgroundService.Bot.Services.BackgroundServices;
using TelegramBotWithBackgroundService.Bot.Services.Handlers;
using TelegramBotWithBackgroundService.Bot.Services.UserRepositories;

namespace TelegramBotWithBackgroundService.Bot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<HostOptions>(options =>
            {
                options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
            });


            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddDbContext<AppBotDbContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Port=5432;Database=BackgroundDb;User Id=postgres;Password=<your password>;");
            });
            builder.Services.AddScoped<BotUpdateHandler>();

            var botConfig = builder.Configuration.GetSection("BotConfiguration")
    .Get<BotConfiguration>();

            builder.Services.AddHttpClient("webhook")
                .AddTypedClient<ITelegramBotClient>(httpClient
                    => new TelegramBotClient(botConfig.Token, httpClient));

            builder.Services.AddHostedService<ConfigureWebhook>();
            builder.Services.AddHostedService<MyBackgroundService>();

            var app = builder.Build();



            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseCors(ops =>
            {
                ops.AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowAnyOrigin();
            });


            app.UseEndpoints(endpoints =>
            {
                var token = botConfig.Token;

                endpoints.MapControllerRoute(
                    name: "webhook",
                    pattern: $"bot/{token}",
                    new { controller = "WebHookConnect", action = "Connector" });

                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
