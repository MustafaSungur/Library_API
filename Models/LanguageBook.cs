using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace libAPI.Models
{
    public class LanguageBook
    {
        public int BookId { get; set; }

        [JsonIgnore]
        public Book Book { get; set; } = new();

        public required string LanguageId { get; set; }

        public required Language Language { get; set; } = new();
    }
}
