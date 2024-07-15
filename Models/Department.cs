using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{
	public class Department
	{
		public short Id { get; set; }
		
		[StringLength(50)]
		public required string Name { get; set; }
    }
}
