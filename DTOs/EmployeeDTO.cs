using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class EmployeeDTO
	{
		public string Id { get; set; } = string.Empty;

		public int ApplicationUserId { get; set; } 

		public EmployeeTitleDTO Title { get; set; }

		public short DepartmentId { get; set; }

		public DepartmentDTO Department { get; set; }

		[Range(0, double.MaxValue)]
		public decimal Salary { get; set; }

		public ShiftDTO Shift { get; set; }
	}

}
