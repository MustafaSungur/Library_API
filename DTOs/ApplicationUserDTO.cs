using libAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class ApplicationUserCreateDTO
	{
		public long IdNumber { get; set; }

		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public short GenderId { get; set; }

		public AddressCreateDTO Address { get; set; } = new();

		public DateTime BirthDate { get; set; }

		public string? PhotoUrl { get; set; }

		public string? PhoneNumber { get; set; }

		public string? Email { get; set; }

		public string Password { get; set; } = string.Empty;

		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; } = string.Empty;
	}

	public class ApplicationUserReadDTO
	{
		public string Id { get; set; } = string.Empty;

		public long IdNumber { get; set; }

		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public GenreReadDTO? Gender { get; set; }

		public AddressReadDTO Address { get; set; } = new();

		public DateTime BirthDate { get; set; }

		public DateTime RegisterDate { get; set; }

		public bool Status { get; set; }

		public string? PhotoUrl { get; set; }
	}
}
