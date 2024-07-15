using System.ComponentModel.DataAnnotations.Schema;

namespace libAPI.Models
{
	public class BorrowBooks
	{
		public int Id { get; set; }

		public required Employee Librarian { get; set; }

		public int BookId { get; set; }

		[ForeignKey(nameof(BookId))]
		public required Book Book { get; set; } = new();

		public required string MemberId { get; set; }

		[ForeignKey(nameof(MemberId))]
		public required Member Member { get; set; }

		public required DateTime RentalDate { get; set; } = DateTime.Now;

		public required DateTime Deadline { get; set; }

		[NotMapped]
		public List<int>? BooksId { get; set; }
    }
}
