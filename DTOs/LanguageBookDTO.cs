namespace libAPI.DTOs
{
	public class LanguageBookCreateDTO
	{
		public int BookId { get; set; }
		public string LanguageId { get; set; } = string.Empty;
	}

	public class LanguageBookReadDTO
	{
		public int BookId { get; set; }
		public string LanguageId { get; set; } = string.Empty;
		public BookReadDTO? Book { get; set; }
		public LanguageReadDTO? Language { get; set; }
	}
}
