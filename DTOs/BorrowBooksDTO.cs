using libAPI.Models;

namespace libAPI.DTOs
{
	public class BorrowBooksCreateDTO
	{
		public int Id { get; set; }
		public string MemberId { get; set; } = string.Empty;
		public DateTime RentalDate { get; set; }
		public DateTime Deadline { get; set; }
		public List<int>? BooksId { get; set; }
	}

	public class BorrowBooksReadDTO
	{
		public int Id { get; set; }
        public MemberReadDTO? Member { get; set; }
		public BookReadDTO? Book { get; set; }
        //public EmployeeReadDTO Employee { get; set; }
        public DateTime RentalDate { get; set; }
		public DateTime Deadline { get; set; }
        public string? EmployeeId { get; set; }
		public string? EmployeeFirstName { get; set; }
		public string? EmployeeLastName { get; set; }
	}
}
