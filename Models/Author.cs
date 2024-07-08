using System;
namespace libAPI.Models
{
	public class Author
	{
		public long Id { get; set; }
		public string Fullname { get; set; } = string.Empty;
		public string? Biography { get; set; }
		public DateTime BirthDate { get; set; }
		public short? DeadYear { get; set; }
		public List<Book>? Books { get; set; }

	}
}


