using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libAPI.Models
{
	public class Address
	{
		public int Id { get; set; }

		[Required]
		public short AddressCountryId { get; set; }

		[ForeignKey(nameof(AddressCountryId))]
		public AddressCountry? Country { get; set; } 

		[Required]
		public short AddressCityId { get; set; }

		[ForeignKey(nameof(AddressCityId))]
		public AddressCity? City { get; set; }

		[StringLength(250)]
		[Required]
		public string ClearAddress { get; set; } = string.Empty;
	}
}
