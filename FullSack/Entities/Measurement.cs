namespace FullSack.Entities
{
	public class Measurement
	{
		public int MeasurementId { get; set; }
		public string Category { get; set; } = null!;
		public string Symbol { get; set; } = null!;

		public virtual ICollection<Ingredient> IngredientNavProp { get; set; } = new List<Ingredient>();
	}
}
