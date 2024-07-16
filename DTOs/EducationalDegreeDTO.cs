using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class EducationalDegreeDTO
	{
		public short Id { get; set; }

		[StringLength(50)]
		public string Degree { get; set; } = string.Empty;
	}

}
