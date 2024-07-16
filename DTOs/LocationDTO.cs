using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class LocationDTO
	{
		public int Id { get; set; }

		[StringLength(6, MinimumLength = 1)]
		public string Shelf { get; set; } = string.Empty;

	}

}
