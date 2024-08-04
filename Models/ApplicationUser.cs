using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace libAPI.Models
{
	public class ApplicationUser:IdentityUser
	{
		public long IdNumber{ get; set; }

		[StringLength(50)]
		public string FirstName { get; set; } = "";

		[StringLength(50)]
		public string LastName { get; set; } = "";
		
		public short GenderId { get; set; }

		[ForeignKey(nameof(GenderId))]
		public Genre? Gender { get; set; }

		public int? AddressId { get; set; }

		[ForeignKey(nameof(AddressId))]
		public  Address? Address { get; set; }

		public DateTime BirthDate { get; set; }
		
		public DateTime RegisterDate { get; set; }

		public bool Status { get; set; } 

		[NotMapped]
		public string? Password { get; set; }

		[NotMapped]
		[Compare(nameof(Password))]
		public string? ConfirmPassword { get; set; }

	}
}
