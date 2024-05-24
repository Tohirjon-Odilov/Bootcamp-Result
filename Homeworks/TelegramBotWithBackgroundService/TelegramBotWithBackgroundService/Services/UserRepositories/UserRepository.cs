using Microsoft.EntityFrameworkCore;
using TelegramBotWithBackgroundService.Bot.Models;
using TelegramBotWithBackgroundService.Bot.Persistance;

namespace TelegramBotWithBackgroundService.Bot.Services.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppBotDbContext _appBotDbContext;

        public UserRepository(AppBotDbContext context)
        {
            _appBotDbContext = context;
        }

        public async Task Add(UserModel user)
        {
            var res = await _appBotDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (res != null)
            {
                return;
            }
            await _appBotDbContext.Users.AddAsync(user);
            await _appBotDbContext.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _appBotDbContext.Users.ToListAsync();
        }
    }

}
