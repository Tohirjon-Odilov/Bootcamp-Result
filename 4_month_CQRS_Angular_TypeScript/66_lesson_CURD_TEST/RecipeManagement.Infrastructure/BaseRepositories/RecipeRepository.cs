using RecipeManagement.Application.Abstractions;
using RecipeManagement.Domain.Entities.Models;
using RecipeManagement.Infrastructure.Persistance;

namespace RecipeManagement.Infrastructure.BaseRepositories
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RecipeManagementDbContext context) : base(context)
        {
        }
    }
}
