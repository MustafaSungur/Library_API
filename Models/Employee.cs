using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{
	public class Employee
	{
		[Key]
		public string Id { get; set; } = "";

		[ForeignKey(nameof(Id))]
		public ApplicationUser? ApplicationUser { get; set; }

		public required EmployeeTitle Title { get; set; }

		public required short DepartmentId { get; set; }

		[ForeignKey(nameof(DepartmentId))]
		public required Department Department { get; set; }

		[Range(0, double.MaxValue)]
		public decimal Salary { get; set; }

		public required Shift Shift { get; set; }
	}
}