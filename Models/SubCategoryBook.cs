using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text.Json.Serialization;

namespace libAPI.Models
{
	public class SubCategoryBook
	{
		public int BookId { get; set; }

		[JsonIgnore]
		public required Book Book { get; set; } 

		public short SubCategoryId { get; set; }

		[JsonIgnore]
		public required SubCategory SubCategory { get; set; }
	}
}
