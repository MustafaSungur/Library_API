using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class MemberManager : GenericManager<Member, MemberDTO, libAPIContext,string>, IMemberService
	{
		public MemberManager(IRepository<Member, libAPIContext,string> repository) : base(repository)
		{
		}
		protected override Member MapToEntity(MemberDTO dto)
		{
			return new Member
			{
				Id = dto.Id,
				ApplicationUser = new ApplicationUser
				{
					Id = dto.ApplicationUserId.ToString(),
					Address = new Address() // Boş bir Address nesnesi başlatılıyor
				},
				EducationalDegree = new EducationalDegree { Id = dto.EducationalDegree.Id, Degree = dto.EducationalDegree.Degree },
				PenaltyPoint = dto.PenaltyPoint,
				IsBanned = dto.IsBanned,
				EndBannedDate = dto.EndBannedDate,
				// BorrowingHistory property mapping can be included if necessary
			};
		}

		protected override MemberDTO MapToDto(Member entity)
		{
			return new MemberDTO
			{
				Id = entity.Id,
				ApplicationUserId = int.Parse(entity.ApplicationUser.Id), // Assuming ApplicationUser Id is a string
				EducationalDegree = new EducationalDegreeDTO { Id = entity.EducationalDegree.Id, Degree = entity.EducationalDegree.Degree },
				PenaltyPoint = entity.PenaltyPoint,
				IsBanned = entity.IsBanned,
				EndBannedDate = entity.EndBannedDate,
				// BorrowingHistory property mapping can be included if necessary
			};
		}


	}
}
