using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace libAPI.Models
{
	public class LanguageBook
	{
		public int BookId { get; set; }

		[JsonIgnore]
		public Book Book { get; set; } = new();

		public required string LanguageId { get; set; }

		[JsonIgnore]
		public Language Language { get; set; } = new();
	}
}
