using libAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class ApplicationUserDTO
	{
		public string Id { get; set; } = string.Empty;
		public long IdNumber { get; set; }

		[StringLength(50)]
		public string FirstName { get; set; } = string.Empty;

		[StringLength(50)]
		public string LastName { get; set; } = string.Empty;

		public Genre? Gender { get; set; }

		public AddressDTO Address { get; set; }

		public DateTime BirthDate { get; set; }

		public DateTime RegisterDate { get; set; }

		public bool Status { get; set; }

		public string? PhotoUrl { get; set; }

		[NotMapped]
		public string? Password { get; set; }

		[NotMapped]
		[Compare(nameof(Password))]
		public string? ConfirmPassword { get; set; }
	}

}
