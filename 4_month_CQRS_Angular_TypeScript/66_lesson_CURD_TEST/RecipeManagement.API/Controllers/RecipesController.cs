using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeManagement.API.Attributes;
using RecipeManagement.API.ExternalServices;
using RecipeManagement.Application.Abstractions.IServices;
using RecipeManagement.Domain.Entities.DTOs;
using RecipeManagement.Domain.Entities.Enums;
using RecipeManagement.Domain.Entities.Models;

namespace RecipeManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IWebHostEnvironment _env;

        public RecipesController(IRecipeService recipeService, IWebHostEnvironment env)
        {
            _recipeService = recipeService;
            _env = env;
        }

        [HttpPost]
        [IdentityFilter(Permission.CreateRecipe)]
        public async Task<ActionResult<Recipe>> CreateRecipe([FromForm] RecipeDTO model, IFormFile InstructionsPath)
        {
            if (model.Rating < 1 && model.Rating > 5)
            {
                return BadRequest("Rating must be from 1 to 5");
            }

            FileExternalService service = new FileExternalService(_env);

            string picturePath = await service.AddFileAndGetPath(InstructionsPath);

            var result = await _recipeService.Create(model, picturePath);

            return Ok(result);
        }

        [HttpGet]
        [IdentityFilter(Permission.GetAllRecipes)]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAllRecipes()
        {
            var result = await _recipeService.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [IdentityFilter(Permission.GetRecipeById)]
        public async Task<ActionResult<Recipe>> GetRecipeById(int id)
        {
            var result = await _recipeService.GetById(id);

            return Ok(result);
        }

        [HttpPut]
        [IdentityFilter(Permission.UpdateRecipe)]
        public async Task<ActionResult<Recipe>> UpdateRecipe(int id, RecipeDTO model, IFormFile InstructionsFile)
        {
            if (model.Rating < 1 && model.Rating > 5)
            {
                return BadRequest("Rating must be from 1 to 5");
            }

            FileExternalService service = new FileExternalService(_env);

            string picturePath = await service.AddFileAndGetPath(InstructionsFile);

            var result = await _recipeService.Update(id, model, picturePath);

            return Ok(result);
        }

        [HttpDelete]
        [IdentityFilter(Permission.DeleteRecipe)]
        public async Task<ActionResult<string>> DeleteRecipe(int id)
        {
            var result = await _recipeService.Delete(x => x.Id == id);

            if (!result)
            {
                return BadRequest("Something went wrong...");
            }

            return Ok("Deleted successfully");
        }
    }
}
