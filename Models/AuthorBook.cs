using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace libAPI.Models
{
	public class AuthorBook
	{

		public long AuthorId { get; set; }

		[JsonIgnore]
		public Author Author { get; set; } = new();

		public int BookId { get; set; }

		[JsonIgnore]
		public Book Book { get; set; } = new();
	}
}
