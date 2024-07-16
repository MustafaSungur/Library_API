using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{
	public class Language
	{
		[Key]
		[StringLength(5, MinimumLength = 2)]
		public string Code { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		public List<LanguageBook>? LanguageBooks { get; set; }
	}
}
