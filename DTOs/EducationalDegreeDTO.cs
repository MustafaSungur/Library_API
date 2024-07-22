using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class  EducationalCreateDTO
	{
		public short Id { get; set; }

		public string Degree { get; set; } = string.Empty;

	}

	public class EducationalReadDTO
	{
		public short Id { get; set; }
		public string Degree { get; set; } = string.Empty;

	}

	
}
