using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalBrand.Domain.Entities.Auth;

namespace IdentityLayer.Persistanse
{
    public class AuthDbContext : IdentityDbContext<UserModel, IdentityRole<long>, long>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
