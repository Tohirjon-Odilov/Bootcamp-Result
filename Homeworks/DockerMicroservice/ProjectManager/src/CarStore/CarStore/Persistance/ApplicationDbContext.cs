using CarStore.Etities;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
    }
}
