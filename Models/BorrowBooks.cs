using System.ComponentModel.DataAnnotations.Schema;

namespace libAPI.Models
{
	public class BorrowBooks
	{
		public int Id { get; set; }


		public  int BookId { get; set; }

		[ForeignKey(nameof(BookId))]
		public  Book Book { get; set; } 

		public required string MemberId { get; set; }

		[ForeignKey(nameof(MemberId))]
		public  Member Member { get; set; }

		//public required int EmployeeId { get; set; }

		//[ForeignKey(nameof(EmployeeId))]
		//public Employee Employee { get; set; }

		public required DateTime RentalDate { get; set; } = DateTime.Now;

		public required DateTime Deadline { get; set; }

		[NotMapped]
		public List<int>? BooksId { get; set; }
	}
}