using Microsoft.EntityFrameworkCore;
using Ordering.Application.Abstraction;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderingDbContext:DbContext, IOrderingDbContext
    {
        public OrderingDbContext(DbContextOptions<OrderingDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
    }
}
