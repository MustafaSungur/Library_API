namespace libAPI.DTOs
{
	public class SubCategoryBookDTO
	{
		public int BookId { get; set; }

		public short SubCategoryId { get; set; }

		public BookDTO? Book { get; set; }
		public SubCategoryDTO? SubCategory { get; set; }
	}

}
