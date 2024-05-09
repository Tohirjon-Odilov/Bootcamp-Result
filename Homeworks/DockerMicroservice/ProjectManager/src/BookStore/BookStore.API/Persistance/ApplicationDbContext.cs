using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Persistance
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
