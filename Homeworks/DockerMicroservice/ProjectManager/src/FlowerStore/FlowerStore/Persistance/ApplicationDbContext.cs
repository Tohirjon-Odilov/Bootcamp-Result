using FlowerStore.Etities;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Flower> Flowers { get; set; }
    }
}
