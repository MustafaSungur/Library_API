using libAPI.Models;

namespace libAPI.DTOs
{
	public class StockCreateDTO
	{
		public string? ISBM { get; set; }
		public int TotalCopies { get; set; }
		public int AvailableCopies { get; set; }
	}

	public class StockReadDTO
	{
        public string? ISBM { get; set; }
        public int TotalCopies { get; set; }
		public int AvailableCopies { get; set; }
	}
}
