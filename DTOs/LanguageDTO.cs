using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class LanguageCreateDTO
	{
		public string Code { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;
	}

	public class LanguageReadDTO
	{
		public string Code { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;
	}
}
