using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class PublisherDTO
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

	}

}
