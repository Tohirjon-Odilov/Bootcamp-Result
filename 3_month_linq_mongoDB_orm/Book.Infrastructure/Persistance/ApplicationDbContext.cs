using Book.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<LibraryBook> Books { get; set; }
    }
}
