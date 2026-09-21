namespace FullSack.DTO.RecipeGet
{
	public class RecipePageIngredientDTO
	{
		public string IngredientId { get; set; } = null!;
		public string Title { get; set; } = null!;
		public byte Position { get; set; }
		public int MeasurementId { get; set; }
		public decimal MeasurementValue { get; set; }
	}
}
