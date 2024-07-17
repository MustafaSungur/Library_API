using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class StockDTO
	{
		public int Id { get; set; }
		public int BookId { get; set; }
		public int TotalCopies { get; set; }
		public int AvailableCopies { get; set; }
	}


}
