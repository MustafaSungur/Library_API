namespace libAPI.DTOs
{
	public class SubCategoryBookCreateDTO
	{
		public int BookId { get; set; }
		public short SubCategoryId { get; set; }
	}

	public class SubCategoryBookReadDTO
	{
		public int BookId { get; set; }
		public short SubCategoryId { get; set; }
		public BookReadDTO? Book { get; set; }
		public SubCategoryReadDTO? SubCategory { get; set; }
	}
}
