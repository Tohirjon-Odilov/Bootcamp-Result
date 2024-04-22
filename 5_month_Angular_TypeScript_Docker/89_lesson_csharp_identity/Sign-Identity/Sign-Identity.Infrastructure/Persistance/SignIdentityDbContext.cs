using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sign_Identity.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sign_Identity.Infrastructure.Persistance
{
    public class SignIdentityDbContext : IdentityDbContext<User>
    {
        public SignIdentityDbContext(DbContextOptions<SignIdentityDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
