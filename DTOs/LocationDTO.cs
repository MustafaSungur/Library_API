using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class LocationCreateDTO
	{
		public int Id { get; set; }

		public string Shelf { get; set; } = string.Empty;

	}

	public class LocationReadDTO
	{
		public int Id { get; set; }
		public string Shelf { get; set; } = string.Empty;

	}
}
