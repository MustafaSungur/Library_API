using System;
using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class AuthorCreateDTO
	{
		public long Id { get; set; }

		public string FullName { get; set; } = string.Empty;

		public string? Biography { get; set; }

		public DateTime BirthDate { get; set; }

		public short? DeadYear { get; set; }
	}

	public class AuthorReadDTO
	{
		public long Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public string? Biography { get; set; }
		public DateTime BirthDate { get; set; }
		public short? DeadYear { get; set; }
	}
}
