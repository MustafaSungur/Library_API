using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libAPI.Models
{
	public class Stock
	{
		[Key]
		public required string ISBM { get; set; }
	
		[Range(0, int.MaxValue)]
		public int TotalCopies { get; set; }

		[Range(0, int.MaxValue)]
		public int AvailableCopies { get; set; }
	}
}
