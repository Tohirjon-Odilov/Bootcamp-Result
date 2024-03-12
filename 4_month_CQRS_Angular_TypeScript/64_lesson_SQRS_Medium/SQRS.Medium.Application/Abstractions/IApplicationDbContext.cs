using Microsoft.EntityFrameworkCore;
using SQRS.Medium.Domain.Entities;

namespace SQRS.Medium.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
