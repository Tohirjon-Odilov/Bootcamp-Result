using GameStore.Etities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
    }
}
