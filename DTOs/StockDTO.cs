using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class StockDTO
	{
		public int Id { get; set; }

		public int BookId { get; set; }

		[Range(0, int.MaxValue)]
		public int TotalCopies { get; set; }

		[Range(0, int.MaxValue)]
		public int AvailableCopies { get; set; }
	}

}
