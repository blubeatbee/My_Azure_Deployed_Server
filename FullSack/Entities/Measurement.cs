using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FullSack.Entities
{
	[Index(nameof(Category), IsUnique = true)]
	[Index(nameof(Symbol), IsUnique = true)]
	public class Measurement
	{
		[Key]
		public int MeasurementId { get; set; }

		[Required]
		[StringLength(Constants.MeasurementCategory)]
		public string Category { get; set; } = null!;

		[Required]
		[StringLength(Constants.MeasurementSymbol)]
		public string Symbol { get; set; } = null!;

		[ConcurrencyCheck]
		public string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

		public virtual ICollection<Ingredient> IngredientNavProp { get; set; } = new List<Ingredient>();
	}
}
