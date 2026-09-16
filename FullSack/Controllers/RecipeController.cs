using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullSack.Controllers
{
	[ApiController]
	[Route("recipes/")]
	public class RecipeController : ControllerBase
	{
		[HttpGet("search")]
		public async Task<IActionResult> GetRecipeCatalogue(
			[FromQuery(Name = "page")] int pageIndex,
			[FromQuery(Name = "size")] int pageSize)
		{
			try
			{
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpGet("{slug}")]
		public async Task<IActionResult> GetRecipePageContent(
			[FromRoute] string slug)
		{
			try
			{
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> PostRecipe()
		{
			try
			{
				return Created();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[Authorize]
		[HttpPut("{id}")]
		public async Task<IActionResult> PutRecipe(
			[FromRoute] string id)
		{
			try
			{
				return Ok();
			}
			catch (Exception ex)
			{
				return NotFound(ex);
			}
		}

		[Authorize]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRecipe(
			[FromRoute] string id)
		{
			try
			{
				return Ok();
			}
			catch (Exception ex)
			{
				return NotFound(ex);
			}
		}
	}
}
