using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullSack.Entities
{
	public class Ingredient
	{
		[Key]
		[Column(TypeName = Constants.SqlGuid)]
		public string IngredientId { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(RecipeNavProp))]
		[Column(TypeName = Constants.SqlGuid)]
		public string RecipeId { get; set; } = null!;

		[Required]
		[StringLength(Constants.TextLengthShort)]
		public string Title { get; set; } = null!;

		[Required]
		[Range(Constants.ByteMinRange, Constants.ByteMaxRange)]
		public byte Position { get; set; }

		[Required]
		[Column(TypeName = Constants.SqlDecimal)]
		public decimal MeasurementValue { get; set; }

		[Required]
		[ForeignKey(nameof(MeasurementNavProp))]
		public int MeasurementId { get; set; }

		public virtual Recipe RecipeNavProp { get; set; } = null!;
		public virtual Measurement MeasurementNavProp { get; set; } = null!;
	}
}
