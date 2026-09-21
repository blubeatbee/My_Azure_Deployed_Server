namespace FullSack.DTO.RecipePut
{
	public class IngredientPutDTO
	{
		public string? IngredientId { get; set; }
		public string Title { get; set; } = null!;
		public byte Position { get; set; }
		public decimal MeasurementValue { get; set; }
		public int MeasurementId { get; set; }
	}
}
