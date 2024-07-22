
namespace libAPI.DTOs
{
	public class GenreCreateDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
	}

	public class GenreReadDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
	}
}
