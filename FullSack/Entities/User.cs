using Microsoft.AspNetCore.Identity;

namespace FullSack.Entities
{
	public class User : IdentityUser
	{
		public string? Surname { get; set; }
		public string? FirstName { get; set; }

		public virtual ICollection<Recipe> RecipeNavProp { get; set; } = new List<Recipe>();
	}
}
