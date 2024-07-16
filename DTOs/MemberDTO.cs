namespace libAPI.DTOs
{
	public class MemberDTO
	{
		public string Id { get; set; } = string.Empty;

		public int ApplicationUserId { get; set; } 

		public EducationalDegreeDTO EducationalDegree { get; set; } = new EducationalDegreeDTO();

		public short PenaltyPoint { get; set; } = 0;

		public bool IsBanned { get; set; } = false;

		public DateTime? EndBannedDate { get; set; }

	}

}
