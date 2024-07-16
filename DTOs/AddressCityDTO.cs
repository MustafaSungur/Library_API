using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class AddressCityDTO
	{
		public short Id { get; set; }

		[StringLength(50)]
		public string Name { get; set; } = string.Empty;
	}

}
