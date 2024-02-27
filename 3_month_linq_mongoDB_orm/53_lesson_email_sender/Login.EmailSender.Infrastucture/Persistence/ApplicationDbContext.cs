using Login.EmailSender.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Login.EmailSender.Infrastucture.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<SignUpModel> Library { get; set; }
        public virtual DbSet<CheckSendedCode> Books { get; set; }
    }
}
