using TelegramBotWithBackgroundService.Bot.Models;

namespace TelegramBotWithBackgroundService.Bot.Services.UserRepositories
{
    public interface IUserRepository
    {
        public Task Add(UserModel user);
        public Task<List<UserModel>> GetAllUsers();
    }
}
