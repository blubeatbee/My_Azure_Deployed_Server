using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullSack.Entities
{
	[Table("KeywordCategories")]
	[Index(nameof(Title), IsUnique = true)]
	public class KeywordCategory
	{
		[Key]
		public int KeywordCategoryId { get; set; }

		[Required]
		[StringLength(Constants.TextLengthShort)]
		public string Title { get; set; } = null!;

		[ConcurrencyCheck]
		public string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

		public virtual ICollection<Keyword> KeywordNavProp { get; set; } = new List<Keyword>();
	}
}
