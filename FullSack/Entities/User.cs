using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FullSack.Entities
{
	public class User : IdentityUser
	{
		[StringLength(Constants.TextLengthShort)]
		public string? Surname { get; set; }

		[StringLength(Constants.TextLengthShort)]
		public string? FirstName { get; set; }

		public virtual ICollection<Recipe> RecipeNavProp { get; set; } = new List<Recipe>();
	}
}
