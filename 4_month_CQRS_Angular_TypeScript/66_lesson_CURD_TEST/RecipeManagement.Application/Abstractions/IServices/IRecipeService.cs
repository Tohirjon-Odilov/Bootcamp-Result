using RecipeManagement.Domain.Entities.DTOs;
using RecipeManagement.Domain.Entities.Models;
using System.Linq.Expressions;

namespace RecipeManagement.Application.Abstractions.IServices
{
    public interface IRecipeService
    {
        public Task<Recipe> Create(RecipeDTO recipeDTO, string instructionsPath);
        public Task<IEnumerable<Recipe>> GetAll();
        public Task<Recipe> GetById(int id);
        public Task<Recipe> Update(int id, RecipeDTO recipeDTO, string instructionsPath);
        public Task<bool> Delete(Expression<Func<Recipe, bool>> expression);
    }
}
