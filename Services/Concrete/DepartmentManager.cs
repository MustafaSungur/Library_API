using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class DepartmentManager : GenericManager<Department, DepartmentCreateDTO, DepartmentReadDTO, libAPIContext, short>, IDepartmentsService
	{
		public DepartmentManager(IRepository<Department, libAPIContext, short> repository) : base(repository)
		{
		}

		public override Department MapToEntity(DepartmentCreateDTO dto)
		{
			return new Department
			{
				Name = dto.Name
			};
		}

		public override DepartmentReadDTO MapToDto(Department entity)
		{
			return new DepartmentReadDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}

		public override DepartmentCreateDTO MapToCreateDto(DepartmentReadDTO entity)
		{
			return new DepartmentCreateDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}
	}
}
