using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libAPI.Models
{
	public class Member
	{
		[Key]
		public string Id { get; set; } = "";

		[ForeignKey(nameof(Id))]
		public ApplicationUser? ApplicationUser { get; set; }

		public short EducationalDegreeId { get; set; } 

		[ForeignKey(nameof(EducationalDegreeId))]
		public EducationalDegree? EducationalDegree { get; set; } 

		public short PenaltyPoint { get; set; } = 0;

		public bool IsBanned { get; set; } = false;

        public DateTime? EndBannedDate { get; set; }


		public List<BorrowHistory>? BorrowingHistory { get; set; } 
	}
}
