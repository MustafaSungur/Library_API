using System;
using System.Text.Json.Serialization;
namespace libAPI.Models
{
	public class Publisher
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Phone { get; set; }
		public string? Email { get; set; }
		public string? ContactPerson { get; set; }

		[JsonIgnore]
		public List<Book>? Books { get; set; }
	}
}

