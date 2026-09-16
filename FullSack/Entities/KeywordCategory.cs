namespace FullSack.Entities
{
	public class KeywordCategory
	{
		public int KeywordCategoryId { get; set; }
		public string Title { get; set; } = null!;

		public virtual ICollection<Keyword> KeywordNavProp { get; set; } = new List<Keyword>();
	}
}
