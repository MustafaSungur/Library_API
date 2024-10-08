﻿using libAPI.Models;

namespace libAPI.DTOs
{
	public class BorrowHistoryCreateDTO
	{
		public int Id { get; set; }

		public string MemberId { get; set; } = string.Empty;
		public int BookId { get; set; }
		public DateTime BorrowedDate { get; set; }
		public DateTime? ReturnedDate { get; set; }
		public bool IsReturned { get; set; }
		public bool IsPenaltyApplied { get; set; }
	}
	public class BorrowHistoryReadDTO
	{
		public int Id { get; set; }
		public string? MemberId { get; set; }
		public BookReadDTO? Book { get; set; }
		public DateTime BorrowedDate { get; set; }
		public DateTime? ReturnedDate { get; set; }
		public DateTime? RegisterDate { get; set; }
		public bool IsReturned { get; set; }
		public bool IsPenaltyApplied { get; set; }
		public string? BorrowingEmployeeId { get; set; }
		public string? BorrowingEmployeeFirstName { get; set; }
		public string? BorrowingEmployeeLastName { get; set; }
		public string? LendingEmployeeId { get; set; } = "";
		public string? LendingEmployeeFirstName { get; set; } = "";
		public string? LendingEmployeeLastName { get; set; } = "";
	}

}
