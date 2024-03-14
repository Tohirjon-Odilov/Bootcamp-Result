using Microsoft.EntityFrameworkCore;
using RecipeManagement.Domain.Entities.Models;

namespace RecipeManagement.Infrastructure.Persistance
{
    public class RecipeManagementDbContext : DbContext
    {
        public RecipeManagementDbContext(DbContextOptions<RecipeManagementDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
    }
}
