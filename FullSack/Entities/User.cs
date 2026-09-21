using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FullSack.Entities
{
	public class User : IdentityUser
	{
		public byte[]? ProfileImage { get; set; }

		[StringLength(Constants.TextLengthShort)]
		public string? Surname { get; set; }

		[StringLength(Constants.TextLengthShort)]
		public string? NormalizedSurname { get; set; }

		[StringLength(Constants.TextLengthShort)]
		public string? FirstName { get; set; }

		[StringLength(Constants.TextLengthShort)]
		public string? NormalizedFirstName { get; set; }

		public virtual ICollection<Recipe> RecipeNavProp { get; set; } = new List<Recipe>();
	}
}
