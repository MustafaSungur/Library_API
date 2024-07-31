using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{
	public class BorrowHistory
	{
		public int Id { get; set; }

		public required string MemberId { get; set; }

		[ForeignKey(nameof(MemberId))]
		public Member? Member { get; set; }

		public required int BookId { get; set; }

		[ForeignKey(nameof(BookId))]
		public Book? Book { get; set; }

		public string? BorrowingEmployeeId { get; set; }

		[ForeignKey(nameof(BorrowingEmployeeId))]
		public Employee? BorrowingEmployee { get; set; }

		public string? LendingEmployeeId { get; set; }

		[ForeignKey(nameof(LendingEmployeeId))]
		public Employee? LendingEmployee { get; set; }

		public required DateTime BorrowedDate { get; set; }

		public DateTime? ReturnedDate { get; set; }

		public required bool IsReturned { get; set; }

		public required bool IsPenaltyApplied { get; set; }

		public DateTime RegisterDate { get; set; } = DateTime.Now;

     
    }
}