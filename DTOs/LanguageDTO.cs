using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class LanguageDTO
	{
		[StringLength(5, MinimumLength = 2)]
		public string Code { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		
	}

}
