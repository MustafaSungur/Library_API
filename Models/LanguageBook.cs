using System.Text.Json.Serialization;

namespace libAPI.Models
{
    public class LanguageBook
    {
        public int BookId { get; set; }

        [JsonIgnore]
        public Book? Book { get; set; } 

        public required string LanguageId { get; set; }

        public  Language? Language { get; set; } 
    }
}
