using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class EducationalDegreeManager : GenericManager<EducationalDegree, EducationalCreateDTO, EducationalReadDTO, libAPIContext, short>, IEducationalDegreeService
	{
		public EducationalDegreeManager(IRepository<EducationalDegree, libAPIContext, short> repository) : base(repository)
		{
		}

		public override EducationalDegree MapToEntity(EducationalCreateDTO dto)
		{
			return new EducationalDegree
			{
				Degree = dto.Degree
			};
		}

		public override EducationalReadDTO MapToDto(EducationalDegree entity)
		{
			return new EducationalReadDTO
			{
				Id = entity.Id,
				Degree = entity.Degree
			};
		}
	}
}
