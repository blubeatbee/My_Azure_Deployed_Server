using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullSack.Entities
{
	/// <summary>
	///	Represents a junction table between <see cref="Entities.Recipe"/> and <see cref="Entities.Keyword"/>.
	/// </summary>
	[Table("KeywordsRecipes")]
	[PrimaryKey(nameof(RecipeId), nameof(KeywordId))]
	public class KeywordRecipe
	{
		[Column(TypeName = Constants.SqlGuid)]
		[ForeignKey(nameof(Recipe))]
		public string RecipeId { get; set; } = null!;

		[ForeignKey(nameof(Keyword))]
		public int KeywordId { get; set; }

		public virtual Recipe Recipe { get; set; } = null!;
		public virtual Keyword Keyword { get; set; } = null!;
	}
}
