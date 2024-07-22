using System.ComponentModel.DataAnnotations;
using libAPI.Models;

namespace libAPI.DTOs
{
	public class SubCategoryCreateDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public short CategoryId { get; set; }
	}

	public class SubCategoryReadDTO
	{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;

        public CategoryReadDTO? Category { get; set; }

        public List<SubCategoryBookReadDTO>? SubCategoryBooks { get; set; }
	}
}
