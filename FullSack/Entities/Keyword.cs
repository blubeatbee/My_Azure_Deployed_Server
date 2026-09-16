namespace FullSack.Entities
{
	public class Keyword
	{
		public int KeywordId { get; set; }
		public int KeywordCategoryId { get; set; }
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;

		public virtual KeywordCategory KeywordCategoryNavProp { get; set; } = null!;
	}
}
