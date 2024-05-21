using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalBrand.Application.Abstractions;
using PersonalBrand.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Infrastructure.Persistance
{
    public class PersonalBrandDbContext : IdentityDbContext<UserModel, IdentityRole<long>, long>, IApplicationDbContext
    {

        public PersonalBrandDbContext(DbContextOptions<PersonalBrandDbContext> options)
            : base(options)
                => Database.Migrate();


        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
              => await base.SaveChangesAsync(cancellationToken);

    }
}
