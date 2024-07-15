using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace libAPI.Models
{
	public class Publisher
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; } = string.Empty;

		[Phone]
		public string? Phone { get; set; }

		[EmailAddress]
		public string? Email { get; set; }

		[StringLength(100)]
		public string? ContactPerson { get; set; }

		[JsonIgnore]
		public List<Book>? Books { get; set; }
	}
}
