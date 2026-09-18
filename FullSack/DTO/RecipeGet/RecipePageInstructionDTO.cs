namespace FullSack.DTO.RecipeGet
{
	public class RecipePageInstructionDTO
	{
		public string InstructionId { get; set; } = null!;
		public byte Step { get; set; }
		public string Description { get; set; } = null!;
	}
}
