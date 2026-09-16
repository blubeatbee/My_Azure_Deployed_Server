namespace FullSack.Entities
{
	public class Ingredient
	{
		public string IngredientId { get; set; } = null!;
		public string RecipeId { get; set; } = null!;
		public string Title { get; set; } = null!;
		public byte Position { get; set; }
		public decimal MeasurementValue { get; set; }
		public int MeasurementId { get; set; }

		public virtual Recipe RecipeNavProp { get; set; } = null!;
		public virtual Measurement MeasurementNavProp { get; set; } = null!;
	}
}
