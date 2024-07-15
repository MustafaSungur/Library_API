using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{

	public class Address
	{
        public int Id { get; set; }

        public required AddressCountry Country { get; set; }

		public required SubCategory City { get; set; }

		[StringLength(250)]
		public required string ClearAddress { get; set; }

	}
}
