using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{
	public class Category
	{
		public short Id { get; set; }

		[StringLength(50)]
		public required string Name { get; set; } 

		public List<SubCategory>? SubCategories{ get; set; }
	}

}