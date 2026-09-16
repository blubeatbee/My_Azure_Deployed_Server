namespace FullSack.Entities
{
	public class Recipe
	{
		public string RecipeId { get; set; } = null!;
		public string? UserId { get; set; }
		public string Title { get; set; } = null!;
		public string Slug { get; set; } = null!;
		public string? Description { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateUpdated { get; set; }

		public virtual User? UserNavProp { get; set; }
		public virtual ICollection<Ingredient> IngredientNavProp { get; set; } new List<Ingredient>();
		public virtual ICollection<Instruction> InstructionNavProp { get; set; } new List<Instruction>();
	}
}
