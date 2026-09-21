namespace FullSack.DTO.RecipeGet
{
	public class RecipeCatalogueDTO
	{
		public string RecipeId { get; set; } = null!;
		public string Slug { get; set; } = null!;
		public string Title { get; set; } = null!;
		public DateTime DateCreated { get; set; }
		public byte[]? Thumbnail { get; set; }
		public byte? AverageReviewScore { get; set; }

		public string? UserId { get; set; }
		public string? Name { get; set; }
		public byte[]? ProfileImage { get; set; }

	}
}
