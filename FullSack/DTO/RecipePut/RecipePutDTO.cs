namespace FullSack.DTO.RecipePut
{
	public class RecipePutDTO
	{
		public string? RecipeId { get; set; }
		public string UserId { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string? Description { get; set; }
		public DateTime DateCreated { get; set; }

		public ICollection<int> KeywordIds { get; set; } = new List<int>();
		public ICollection<IngredientPutDTO> Ingredients { get; set; } = new List<IngredientPutDTO>();
		public ICollection<InstructionPutDTO> Instructions { get; set; } = new List<InstructionPutDTO>();
	}
}
