using Microsoft.EntityFrameworkCore;
using SQRS.Medium.Application.Abstractions;
using SQRS.Medium.Domain.Entities;

namespace SQRS.Medium.Infrastruct.Persistance
{
    public class MediumDbContext : DbContext, IApplicationDbContext
    {
        public MediumDbContext(DbContextOptions<MediumDbContext> ops)
           : base(ops)
        { }
        public DbSet<User> Users { get; set; }
    }
}
