using System.ComponentModel.DataAnnotations.Schema;

namespace libAPI.DTOs
{
	public class BorrowBooksDTO
	{
		public int Id { get; set; }
		public int BookId { get; set; }
		public string MemberId { get; set; }
		public DateTime RentalDate { get; set; }
		public DateTime Deadline { get; set; }
		public List<int>? BooksId { get; set; }
	}


}
