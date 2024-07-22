using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class AddressCityCreateDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
	}

	public class AddressCityReadDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
	}
}
