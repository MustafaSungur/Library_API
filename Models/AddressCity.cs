using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{
	public class AddressCity
	{
        public short Id { get; set; }

        [StringLength(50)]
        public required string Name { get; set; }
    }
}
