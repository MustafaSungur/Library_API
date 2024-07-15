using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{
	public class Genre
	{
        public short Id{ get; set; }
	
		[StringLength(20)]
		public required string Name { get; set; }
    }
}
