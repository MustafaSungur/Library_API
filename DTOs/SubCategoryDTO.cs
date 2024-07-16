using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class SubCategoryDTO
	{
		public short Id { get; set; }

		[StringLength(100)]
		public string Name { get; set; } = string.Empty;

		public short CategoryId { get; set; }

		public CategoryDTO? Category { get; set; }
		public List<SubCategoryBookDTO>? SubCategoryBooks { get; set; }

	}

}
