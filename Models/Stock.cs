using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libAPI.Models
{
	public class Stock
	{
		[Key]
		public int Id { get; set; }

		public int BookId { get; set; }

		[ForeignKey(nameof(BookId))]
		public  Book Book { get; set; }

		[Range(0, int.MaxValue)]
		public int TotalCopies { get; set; }

		[Range(0, int.MaxValue)]
		public int AvailableCopies { get; set; }
	}
}
