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

		public required DateTime BorrowedDate { get; set; }

		public DateTime? ReturnedDate { get; set; }

		public required bool IsReturned { get; set; }

		public required bool IsPenaltyApplied { get; set; }



	}
}