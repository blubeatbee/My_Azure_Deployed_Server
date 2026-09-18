using FullSack.DTO.RecipeGet;
using FullSack.DTO.RecipePut;
using FullSack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullSack.Controllers
{
	[ApiController]
	[Route("recipes/")]
	public class RecipeController : ControllerBase
	{
		private readonly IRecipeService recipeService;

		public RecipeController(IRecipeService recipeService)
		{
			ArgumentNullException.ThrowIfNull(recipeService);
			this.recipeService = recipeService;
		}

		[HttpGet("search")]
		public async Task<ActionResult<IList<RecipePageDTO>>> GetRecipeCatalogue(
			[FromQuery(Name = "page")] int pageIndex,
			[FromQuery(Name = "size")] int pageSize)
		{
			try
			{
				var result = await this.recipeService.GetRecipesAsListAsync(pageIndex, pageSize);
				return Ok(result);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}

		[HttpGet("{slug}")]
		public async Task<IActionResult> GetRecipePageContent(
			[FromRoute] string slug)
		{
			try
			{
				var result = this.recipeService.GetRecipeBySlugAsync(slug);
				return Ok(result);
			}
			catch (ArgumentException ex)
			{
				return NotFound(ex);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}

		[Authorize]
		[HttpPost]
		public async Task<ActionResult<RecipePageDTO>> PostRecipe([FromBody] RecipePutDTO newRecipe)
		{
			try
			{
				var result = await this.recipeService.AddRecipeAsync(newRecipe);
				return CreatedAtAction(nameof(GetRecipePageContent), new { id = result.RecipeId }, result);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex);
			}
			catch (DbUpdateException ex)
			{
				return Conflict(ex);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}

		[Authorize]
		[HttpPut("{id}")]
		public async Task<ActionResult<RecipePageDTO>> PutRecipe(
			[FromRoute] string id,
			[FromBody] RecipePutDTO updatedRecipe)
		{
			try
			{
				var result = await this.recipeService.UpdateRecipeByIdAsync(id, updatedRecipe);
				return Ok(result);
			}
			catch (ArgumentException ex)
			{
				return NotFound(ex);
			}
			catch (DbUpdateException ex)
			{
				return Conflict(ex);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}

		[Authorize]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRecipe([FromRoute] string id)
		{
			try
			{
				await this.recipeService.RemoveRecipeByIdAsync(id);
				return Ok();
			}
			catch (ArgumentException ex)
			{
				return NotFound(ex);
			}
			catch (DbUpdateException ex)
			{
				return Conflict(ex);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}
	}
}
