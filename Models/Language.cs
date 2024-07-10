using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace libAPI.Models
{
	public class Language
	{
		[Key]
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
		public List<LanguageBook>? LanguageBooks { get; set; }
	}
} 

