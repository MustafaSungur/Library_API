using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class DepartmentManager : GenericManager<Department, DepartmentDTO, libAPIContext,int>, IDepartmentsService
	{
		public DepartmentManager(IRepository<Department, libAPIContext,int> repository) : base(repository)
		{
		}

		protected override Department MapToEntity(DepartmentDTO dto)
		{
			return new Department
			{
				Id = dto.Id,
				Name = dto.Name
			};
		}

		protected override DepartmentDTO MapToDto(Department entity)
		{
			return new DepartmentDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}

	}
}
