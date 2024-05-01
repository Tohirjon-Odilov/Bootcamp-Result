using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Abstraction
{
    public interface IOrderingDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
