namespace libAPI.DTOs
{
	public class BorrowHistoryDTO
	{
		public int Id { get; set; }

		public string MemberId { get; set; } = string.Empty;

		public int BookId { get; set; }

		public DateTime BorrowedDate { get; set; }

		public DateTime? ReturnedDate { get; set; }

		public bool IsReturned { get; set; }

		public bool IsPenaltyApplied { get; set; }
	}

}
