using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class GenreDTO
	{
		public short Id { get; set; }

		[StringLength(20)]
		public string Name { get; set; } = string.Empty;
	}

}
