using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class EmployeeTitleDTO
	{
		public short Id { get; set; }

		[StringLength(30, MinimumLength = 2)]
		public string Name { get; set; } = string.Empty;
	}

}
