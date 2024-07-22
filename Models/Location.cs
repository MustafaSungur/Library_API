using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{
	public class Location
	{
		public int Id { get; set; }

		[StringLength(6, MinimumLength = 1)]
		public string Shelf { get; set; } = "";
        
		public List<Book>? Books { get; set; }

		
    }
}

