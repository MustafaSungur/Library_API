
namespace libAPI.DTOs
{
	public class EmployeeCreateDTO
	{
		public string Id { get; set; } = string.Empty;

		public ApplicationUserCreateDTO ApplicationUserCreateDTO { get; set; }

		public short TitleId { get; set; } = new();

		public short DepartmentId { get; set; }

		public decimal Salary { get; set; }

		public short ShiftId { get; set; }
	}

	public class EmployeeReadDTO
	{
		public string Id { get; set; } = string.Empty;

		public ApplicationUserReadDTO ApplicationUserReadDTO { get; set; }

		public EmployeeTitleReadDTO Title { get; set; } = new();

		public DepartmentReadDTO Department { get; set; } = new();

		public decimal Salary { get; set; }

		public ShiftReadDTO Shift { get; set; } = new();
	}
}
