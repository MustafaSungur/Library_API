
namespace libAPI.DTOs
{
	public class CategoryCreateDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
	}

	public class CategoryReadDTO
	{
		public short Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public List<SubCategoryReadDTO>? SubCategories { get; set; }  
	}
}
