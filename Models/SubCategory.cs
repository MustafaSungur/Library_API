using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace libAPI.Models
{
	public class SubCategory
	{
		public short Id { get; set; }
		public string Name { get; set; } = string.Empty;
        public short CategoryId{ get; set; }

		[JsonIgnore]
		[ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        public List<Book>? Books { get; set; }

    }
}

