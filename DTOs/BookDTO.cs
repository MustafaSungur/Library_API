using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using libAPI.Models;

namespace libAPI.DTOs
{
	public class BookCreateDTO
	{
		public int? Id { get; set; }
		public string Title { get; set; }
		public string ISBM { get; set; }
		public short PageCount { get; set; }
		public short PublishingYear { get; set; }
		public string Description { get; set; }
		public int PrintCount { get; set; }
		public int PublisherId { get; set; }
		public int LocationId { get; set; }
		public string? PhotoUrl { get; set; }
		public short CopyCount { get; set; }
		public List<string> LanguageIds { get; set; }
		public List<short> AuthorsIds { get; set; }
		public List<short> SubCategoryIds { get; set; }
	}

	public class BookReadDTO
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string ISBM { get; set; }
		public short PageCount { get; set; }
		public short PublishingYear { get; set; }
		public string Description { get; set; }
		public int PrintCount { get; set; }
		public int PublisherId { get; set; }
		public int LocationId { get; set; }
		public string PhotoUrl { get; set; }
        public DateTime RegisterDate { get; set; }
        public float Raiting { get; set; }
		public int RaitingCount { get; set; }
		public List<AuthorReadDTO> Authors { get; set; }
		public List<LanguageReadDTO> Languages { get; set; }
		public List<SubCategoryReadDTO> SubCategories { get; set; }
        public Stock Stock { get; set; }
    }

}
