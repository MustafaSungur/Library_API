namespace libAPI.DTOs
{
	public class MemberCreateDTO
	{
		public string Id { get; set; } = string.Empty;

		public ApplicationUserCreateDTO ApplicationUserCreateDTO { get; set; }

		public short EducationalDegreeId { get; set; } 


	}

	public class MemberReadDTO
	{
		public string Id { get; set; } = string.Empty;

		public ApplicationUserReadDTO ApplicationUserReadDTO { get; set; }

		public EducationalReadDTO EducationalDegree { get; set; }

		public short PenaltyPoint { get; set; }

		public bool IsBanned { get; set; }

		
		public DateTime? EndBannedDate { get; set; }
	}
}
