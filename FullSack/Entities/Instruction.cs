namespace FullSack.Entities
{
	public class Instruction
	{
		public string InstructionId { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string RecipeId { get; set; } = null!;

		public virtual Recipe RecipeNavProp { get; set; } = null!;
	}
}
