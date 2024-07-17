using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class EmployeeTitleManager : GenericManager<EmployeeTitle, EmployeeTitleDTO, libAPIContext,int>, IEmployeeTitleService
	{
		public EmployeeTitleManager(IRepository<EmployeeTitle, libAPIContext, int> repository) : base(repository)
		{
		}

		public override EmployeeTitle MapToEntity(EmployeeTitleDTO dto)
		{
			return new EmployeeTitle
			{
				Id = dto.Id,
				Name = dto.Name
			};
		}

		public override EmployeeTitleDTO MapToDto(EmployeeTitle entity)
		{
			return new EmployeeTitleDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}

	}
}
	