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

		public required EducationalDegree EducationalDegree { get; set; }

		public short PenaltyPoint { get; set; } = 0;

		public bool IsBanned { get; set; } = false;

        public DateTime? EndBannedDate { get; set; }
        
		public List<BorrowHistory>? BorrowingHistories { get; set; }
	}
}
