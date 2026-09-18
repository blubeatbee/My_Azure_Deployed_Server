using FullSack.DTO.RecipeGet;
using FullSack.DTO.RecipePut;

namespace FullSack.Services
{
	public interface IRecipeService
	{
		Task<bool> RecipeExistsAsync(string id);
		Task<IList<RecipeCatalogueDTO>> GetRecipesAsListAsync(int pageIndex, int pageSize);
		Task<RecipePageDTO> GetRecipeByIdAsync(string id);
		Task<RecipePageDTO> GetRecipeBySlugAsync(string slug);
		Task<RecipePageDTO> AddRecipeAsync(RecipePutDTO newRecipe);
		Task<RecipePageDTO> UpdateRecipeByIdAsync(string id, RecipePutDTO updatedRecipe);
		Task RemoveRecipeByIdAsync(string id);
	}
}
