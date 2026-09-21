using FullSack.Data;
using FullSack.Entities;
using FullSack.Persistent;

namespace FullSack.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly FullSackDbContext context;

		public UnitOfWork(FullSackDbContext context)
		{
			this.context = context;
			IngredientRepo = new Repository<Ingredient>(this.context);
			InstructionRepo = new Repository<Instruction>(this.context);
			MeasurementRepo = new Repository<Measurement>(this.context);
			KeywordRepo = new Repository<Keyword>(this.context);
			KeywordCategoryRepo = new Repository<KeywordCategory>(this.context);
			KeywordRecipeRepo = new Repository<KeywordRecipe>(this.context);
			RecipeRepo = new RecipeRepository(this.context);
		}

		public IRepository<Ingredient> IngredientRepo { get; private set; }
		public IRepository<Instruction> InstructionRepo { get; private set; }
		public IRepository<Measurement> MeasurementRepo { get; private set; }
		public IRepository<Keyword> KeywordRepo { get; private set; }
		public IRepository<KeywordCategory> KeywordCategoryRepo { get; private set; }
		public IRepository<KeywordRecipe> KeywordRecipeRepo { get; private set; }
		public IRecipeRepository RecipeRepo { get; private set; }

		public async Task<int> SaveAsync()
		{
			return await this.context.SaveChangesAsync();
		}
	}
}
