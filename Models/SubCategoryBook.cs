
using System.Text.Json.Serialization;

namespace libAPI.Models
{
	public class SubCategoryBook
	{
		public int BookId { get; set; }

		[JsonIgnore]
		public Book? Book { get; set; } 

		public short SubCategoryId { get; set; }

		[JsonIgnore]
		public SubCategory? SubCategory { get; set; }
	}
}
