namespace FullSack.DTO.RecipePut
{
	public class InstructionPutDTO
	{
		public string? InstructionId { get; set; }
		public string Description { get; set; } = null!;
		public byte Position { get; set; }
	}
}
