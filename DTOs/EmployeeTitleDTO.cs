using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{

	public class EmployeeTitleCreateDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
	}

	public class EmployeeTitleReadDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
	}
}
