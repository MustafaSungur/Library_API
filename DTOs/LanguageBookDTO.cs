namespace libAPI.DTOs
{
	public class LanguageBookDTO
	{
		public int BookId { get; set; }

		public string LanguageId { get; set; } = string.Empty;

		public BookDTO? Book { get; set; }
		public LanguageDTO? Language { get; set; }
	}

}
