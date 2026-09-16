using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullSack.Entities
{
	[Table("KeywordCategories")]
	public class KeywordCategory
	{
		[Key]
		public int KeywordCategoryId { get; set; }

		[Required]
		[StringLength(Constants.TextLengthShort)]
		public string Title { get; set; } = null!;

		public virtual ICollection<Keyword> KeywordNavProp { get; set; } = new List<Keyword>();
	}
}
