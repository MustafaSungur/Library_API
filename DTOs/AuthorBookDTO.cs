namespace libAPI.DTOs
{
	public class AuthorBookCreateDTO
	{
		public long AuthorId { get; set; }
		public int BookId { get; set; }
	}

	public class AuthorBookReadDTO
	{
		public long AuthorId { get; set; }
		public AuthorReadDTO Author { get; set; } = new();
		public int BookId { get; set; }
		public BookReadDTO Book { get; set; } = new();
	}
}
