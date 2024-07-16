using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class CategoryDTO
	{
		public short Id { get; set; }

		[StringLength(50)]
		public string Name { get; set; } = string.Empty;

		public List<SubCategoryDTO>? SubCategories { get; set; }
	}

}
