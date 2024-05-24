using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotWithBackgroundService.Bot.Models;
using TelegramBotWithBackgroundService.Bot.Persistance;
using TelegramBotWithBackgroundService.Bot.Services.UserRepositories;

namespace TelegramBotWithBackgroundService.Bot.Services.BackgroundServices
{
    public class MyBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ITelegramBotClient _client;

        public MyBackgroundService(IServiceScopeFactory serviceScopeFactory, ITelegramBotClient client)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _client = client;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                    var users = await userRepository.GetAllUsers();

                    foreach (var user in users)
                    {
                        await SendNotification(user, stoppingToken);
                    }
                }
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        private Task SendNotification(UserModel user, CancellationToken token)
        {
            try
            {
                return _client.SendTextMessageAsync(
                    chatId: user.Id,
                    text: "Qales?!",
                    cancellationToken: token);
            }
            catch
            {
                Console.WriteLine("Bloklandi");
                return Task.CompletedTask;
            }
        }
    }
}