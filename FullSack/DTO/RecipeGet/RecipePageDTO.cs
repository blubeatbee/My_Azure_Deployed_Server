namespace FullSack.DTO.RecipeGet
{
	public class RecipePageDTO
	{
		public string RecipeId { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string Slug { get; set; } = null!;
		public string? Description { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime? DateUpdated { get; set; }

		public string? UserId { get; set; }
		public string? Name { get; set; }
		public byte[]? ProfileImage { get; set; }

		public ICollection<int> KeywordIds { get; set; } = new List<int>();
		public ICollection<RecipePageIngredientDTO> Ingredients { get; set; } = new List<RecipePageIngredientDTO>();
		public ICollection<RecipePageInstructionDTO> Instructions { get; set; } = new List<RecipePageInstructionDTO>();

	}
}
