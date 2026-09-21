using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullSack.Entities
{
	[Index(nameof(Title), IsUnique = true)]
	public class Keyword
	{
		[Key]
		public int KeywordId { get; set; }

		[Required]
		[ForeignKey(nameof(KeywordCategoryNavProp))]
		public int KeywordCategoryId { get; set; }

		[Required]
		[StringLength(Constants.TextLengthShort)]
		public string Title { get; set; } = null!;

		[StringLength(Constants.TextLengthMedium)]
		public string Description { get; set; } = null!;

		public virtual KeywordCategory KeywordCategoryNavProp { get; set; } = null!;
		public virtual ICollection<KeywordRecipe> KeywordRecipeNavProp { get; set; } = new List<KeywordRecipe>();
	}
}
