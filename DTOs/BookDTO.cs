using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class BookDTO
	{
		public int Id { get; set; }

		[NotMapped]
		public List<short>? AuthorsIds { get; set; }

		[StringLength(2000)]
		public string Title { get; set; } = string.Empty;

		[StringLength(13, MinimumLength = 10)]
		public string? ISBM { get; set; } = string.Empty;

		[Range(1, short.MaxValue)]
		public short PageCount { get; set; }

		[Range(-4000, 2100)]
		public short PublishingYear { get; set; }

		public string? Description { get; set; }

		[Range(0, int.MaxValue)]
		public int PrintCount { get; set; }

		public int PublisherId { get; set; }

		public List<SubCategoryBookDTO>? SubCategoryBooks { get; set; }

		public List<LanguageBookDTO>? LanguageBooks { get; set; }

		public int LocationId { get; set; }

		public List<AuthorBookDTO>? AuthorBooks { get; internal set; }

		public bool Is { get; set; }

		public string? PhotoUrl { get; set; }

		[NotMapped]
		public short CopyCount { get; set; }
	}

}
