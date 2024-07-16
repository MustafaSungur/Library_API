using System.ComponentModel.DataAnnotations.Schema;

namespace libAPI.DTOs
{
	public class BorrowBooksDTO
	{
		public int Id { get; set; }

		public string? EmployeeId { get; set; } 

		public int BookId { get; set; }

		public string MemberId { get; set; } = string.Empty;

		public DateTime RentalDate { get; set; } = DateTime.Now;

		public DateTime Deadline { get; set; }

		[NotMapped]
		public List<int>? BooksId { get; set; }
	}

}
