using FullSack.Entities;

namespace FullSack.Persistent
{
	public interface IUnitOfWork
	{
		IRepository<Ingredient> IngredientRepo { get; }
		IRepository<Instruction> InstructionRepo { get; }
		IRepository<Measurement> MeasurementRepo { get; }
		IRepository<Keyword> KeywordRepo { get; }
		IRepository<KeywordCategory> KeywordCategoryRepo { get; }
		IRepository<KeywordRecipe> KeywordRecipeRepo { get; }
		IRepository<Recipe> RecipeRepo { get; }

		Task<int> SaveAsync();
	}
}
