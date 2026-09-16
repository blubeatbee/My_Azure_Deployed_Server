using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullSack.Entities
{
	public class Instruction
	{
		[Key]
		[Column(TypeName = Constants.SqlGuid)]
		public string InstructionId { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(RecipeNavProp))]
		[Column(TypeName = Constants.SqlGuid)]
		public string RecipeId { get; set; } = null!;

		[Required]
		[StringLength(Constants.TextLengthLong)]
		public string Description { get; set; } = null!;

		public virtual Recipe RecipeNavProp { get; set; } = null!;
	}
}
