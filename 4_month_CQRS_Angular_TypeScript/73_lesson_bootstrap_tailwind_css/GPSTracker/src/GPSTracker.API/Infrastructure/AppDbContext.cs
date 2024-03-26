using GPSTracker.API.Domain.Entities;
using GPSTracker.API.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace GPSTracker.API.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
            => Database.Migrate();

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(
                    new User()
                    {
                        Id = 1,
                        UserName = "admin",
                        PhoneNumber = "+998912345678",
                        Salt = "8eb3bfb8-a6d7-451d-96c3-7a847c8f72b1",
                        RefreshToken = "1441845a-a3ed-4096-ac7c-454e21cf846a",
                        PasswordHash = "AoL+NXk75HeX0viAK5M26zpK6hDCyx/iPB35io1ZQxg=",
                        ExpireDate = DateTime.Now.AddDays(1),
                    }
                );
        }
    }
}
