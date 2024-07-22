using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class AddressCountryCreateDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
	}

	public class AddressCountryReadDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
	}
}
