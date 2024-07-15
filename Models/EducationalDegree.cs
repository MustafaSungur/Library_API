using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{
	public class EducationalDegree
	{
        public short Id { get; set; }
		
		[StringLength(50)]
		public required string Degree { get; set; }
    }
}
