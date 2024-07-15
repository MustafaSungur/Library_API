using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace libAPI.Models
{
	public class SubCategory
	{
		public short Id { get; set; }

		[StringLength(100)]
		public string Name { get; set; } = string.Empty;

        public short CategoryId{ get; set; }

		[JsonIgnore]
		[ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        public List<SubCategoryBook>? SubCategoryBooks { get; set; }

    }
}

