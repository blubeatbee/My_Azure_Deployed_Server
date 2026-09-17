using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullSack.Entities
{
	public class Recipe
	{
		[Key]
		[Column(TypeName = Constants.SqlGuid)]
		public string RecipeId { get; set; } = null!;

		[ForeignKey(nameof(User))]
		[Column(TypeName = Constants.SqlGuid)]
		public string? UserId { get; set; }

		[Required]
		[StringLength(Constants.TextLengthShort)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(Constants.TextLengthMedium)]
		public string Slug { get; set; } = null!;

		[StringLength(Constants.TextLengthLong)]
		public string? Description { get; set; }

		[Required]
		public DateTime DateCreated { get; set; }

		[Required]
		public DateTime DateUpdated { get; set; }

		public virtual User? UserNavProp { get; set; }
		public virtual ICollection<Ingredient> IngredientNavProp { get; set; } = new List<Ingredient>();
		public virtual ICollection<Instruction> InstructionNavProp { get; set; } = new List<Instruction>();
		public virtual ICollection<KeywordRecipe> KeywordRecipeNavProp { get; set; } = new List<KeywordRecipe>();
	}
}
