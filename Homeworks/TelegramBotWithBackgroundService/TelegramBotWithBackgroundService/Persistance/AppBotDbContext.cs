using Microsoft.EntityFrameworkCore;
using TelegramBotWithBackgroundService.Bot.Models;

namespace TelegramBotWithBackgroundService.Bot.Persistance
{
    public class AppBotDbContext : DbContext
    {
        public AppBotDbContext(DbContextOptions<AppBotDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<UserModel> Users { get; set; }
    }
}