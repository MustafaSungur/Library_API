using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class EmployeeTitleManager : GenericManager<EmployeeTitle, EmployeeTitleCreateDTO, EmployeeTitleReadDTO, libAPIContext, short>, IEmployeeTitleService
	{

		public EmployeeTitleManager(IRepository<EmployeeTitle, libAPIContext, short> repository) : base(repository)
		{
		}

		public override EmployeeTitle MapToEntity(EmployeeTitleCreateDTO dto)
		{
			return new EmployeeTitle
			{
				Id = dto.Id,
				Name = dto.Name
			};
		}

		public override EmployeeTitleReadDTO MapToDto(EmployeeTitle entity)
		{
			return new EmployeeTitleReadDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}

		public override EmployeeTitleCreateDTO MapToCreateDto(EmployeeTitleReadDTO entity)
		{
			return new EmployeeTitleCreateDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}
	}
}
