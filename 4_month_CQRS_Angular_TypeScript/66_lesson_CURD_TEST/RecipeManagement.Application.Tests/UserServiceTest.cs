using Moq;
using RecipeManagement.Application.Abstractions;
using RecipeManagement.Application.Services.RecipeServices;
using RecipeManagement.Domain.Entities.DTOs;
using RecipeManagement.Domain.Entities.Enums;
using RecipeManagement.Domain.Entities.Models;
using System.Linq.Expressions;

namespace RecipeManagement.Application.Tests
{
    public class UserServiceTest
    {

        [Fact]
        public async Task CreateRecipe_ReturnsCreatedRecipe()
        {
            // Arrange
            var mockRepository = new Mock<IRecipeRepository>();
            var recipeService = new RecipeService(mockRepository.Object);

            var recipeDTO = new RecipeDTO()
            {
                Title = "Test",
                Ingredients = new List<string> { "Test" },
                Instructions = new List<string> { "Test" },
                DifficultyLevel = Level.Easy,
                Author = "Test",
                Rating = 5
            };
            var instructionsPath = "path/test";

            var recipe = new Recipe
            {
                Id = 1,
                Title = "Test",
                Ingredients = new List<string> { "Test" },
                Instructions = new List<string> { "Test" },
                InstructionsPath = instructionsPath,
                DifficultyLevel = Level.Easy,
                Author = "Test",
                Rating = 5
            };
            mockRepository.Setup(repo => repo.GetByAny(It.IsAny<Expression<Func<Recipe, bool>>>())).ReturnsAsync(recipe);

            // Act
            await recipeService.Create(recipeDTO, instructionsPath);
            var result = await recipeService.GetById(1);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllRecipes_ReturnsAllRecipes()
        {
            // Arrange
            var mockRepository = new Mock<IRecipeRepository>();
            var recipeService = new RecipeService(mockRepository.Object);
            var recipes = new List<Recipe>()
            {
                new Recipe
                {
                    Id = 1,
                    Title = "Test",
                    Ingredients = new List<string> { "Test" },
                    Instructions = new List<string> { "Test" },
                    InstructionsPath = "path",
                    DifficultyLevel = Level.Easy,
                    Author = "Test",
                    Rating = 5
                },

                new Recipe
                {
                    Id = 2,
                    Title = "Test",
                    Ingredients = new List<string> { "Test" },
                    Instructions = new List<string> { "Test" },
                    InstructionsPath = "path",
                    DifficultyLevel = Level.Easy,
                    Author = "Test",
                    Rating = 5
                }
            };
            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(recipes);

            // Act
            var result = await recipeService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.ElementAt(0) != result.ElementAt(1));
        }

        [Fact]
        public async Task GetRecipeById_ReturnsRecipeById()
        {
            // Arrange
            var mockRepository = new Mock<IRecipeRepository>();
            var recipeService = new RecipeService(mockRepository.Object);
            var recipeId = 2;
            var recipe = new Recipe()
            {
                Id = 2,
                Title = "Test",
                Ingredients = new List<string> { "Test" },
                Instructions = new List<string> { "Test" },
                InstructionsPath = "path",
                DifficultyLevel = Level.Easy,
                Author = "Test",
                Rating = 5
            };
            mockRepository.Setup(repo => repo.GetByAny(It.IsAny<Expression<Func<Recipe, bool>>>())).ReturnsAsync(recipe);

            // Act
            var result = await recipeService.GetById(recipeId);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateRecipe_ReturnsUpdatedRecipe()
        {
            // Arrange
            var mockRepository = new Mock<IRecipeRepository>();
            var recipeService = new RecipeService(mockRepository.Object);
            var recipeId = 1;
            var recipeDTO = new RecipeDTO()
            {
                Title = "Test",
                Ingredients = new List<string> { "Test" },
                Instructions = new List<string> { "Test" },
                DifficultyLevel = Level.Easy,
                Author = "Test",
                Rating = 5
            };
            var instructionsPath = "path";

            var storedRecipe = new Recipe()
            {
                Id = 1,
                Title = "Test",
                Ingredients = new List<string> { "Test" },
                Instructions = new List<string> { "Test" },
                InstructionsPath = "path",
                DifficultyLevel = Level.Easy,
                Author = "Test",
                Rating = 5
            };
            mockRepository.Setup(repo => repo.GetByAny(It.IsAny<Expression<Func<Recipe, bool>>>())).ReturnsAsync(storedRecipe);

            // Act
            await recipeService.Update(recipeId, recipeDTO, instructionsPath);
            var result = await recipeService.GetById(recipeId);

            // Assert
            Assert.Equal(storedRecipe, result);
        }

        public static IEnumerable<object[]> DeleteTestData =>
            new List<object[]>
            {
                new object[] { (Expression<Func<Recipe, bool>>)(x => x.Id == 1), true },
                new object[] { (Expression<Func<Recipe, bool>>)(x => x.Id == 2), true },
                new object[] { (Expression<Func<Recipe, bool>>)(x => x.Id == 3), false },
            };

        [Theory]
        [MemberData(nameof(DeleteTestData))]
        public async Task DeleteRecipe_ReturnsTrue(Expression<Func<Recipe, bool>> expression, bool expectedResult)
        {
            // Arrange
            var mockRepository = new Mock<IRecipeRepository>();
            var recipeService = new RecipeService(mockRepository.Object);
            mockRepository.Setup(repo => repo.Delete(expression)).ReturnsAsync(expectedResult);

            // Act
            var result = await recipeService.Delete(expression);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
