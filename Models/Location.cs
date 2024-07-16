using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libAPI.Models
{
	public class Location
	{
		public int Id { get; set; }

		[StringLength(6,MinimumLength =1)]
		public required string Shelf { get; set; } 
        
		public List<Book>? Books { get; set; }

		
    }
}

