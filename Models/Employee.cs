using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace libAPI.Models
{
	public class Employee
	{
		[Key]
		public string Id { get; set; } = "";

		[ForeignKey(nameof(Id))]
		public ApplicationUser? ApplicationUser { get; set; }

		public short TitleId { get; set; }

		[ForeignKey(nameof(TitleId))]
		public EmployeeTitle? Title { get; set; }

		public required short DepartmentId { get; set; }

		[ForeignKey(nameof(DepartmentId))]
		public Department? Department { get; set; }

		[Range(0, double.MaxValue)]
		public decimal Salary { get; set; }

		public short ShiftId { get; set; }

		[ForeignKey(nameof(ShiftId))]
		public Shift? Shift { get; set; }

	}
}