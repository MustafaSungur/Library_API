using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libAPI.Models
{
	public class EmployeeTitle
	{
        public short Id { get; set; }

		[StringLength(30,MinimumLength =2)]
        public required string  Name { get; set; }
	}
}
