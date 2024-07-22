using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class DepartmentCreateDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
	}

	public class DepartmentReadDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
	}
}
