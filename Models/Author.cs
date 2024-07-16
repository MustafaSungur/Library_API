using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{
    public class Author
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Biography { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Range(0, 9999)]
        public short? DeadYear { get; set; }

        public List<AuthorBook>? AuthorBooks { get; set; }
    }
}
