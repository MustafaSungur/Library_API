using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class EmployeeManager : GenericManager<Employee, EmployeeDTO, libAPIContext,string>, IEmployeeService
	{
		public EmployeeManager(IRepository<Employee, libAPIContext,string> repository) : base(repository)
		{
		}


		public override EmployeeDTO MapToDto(Employee entity)
		{
			return new EmployeeDTO
			{
				Id = entity.Id,
				ApplicationUserId = int.Parse(entity.ApplicationUser.Id), // Assuming ApplicationUser Id is a string
				Title = new EmployeeTitleDTO { Id = entity.Title.Id, Name = entity.Title.Name },
				DepartmentId = entity.DepartmentId,
				Department = new DepartmentDTO { Id = entity.Department.Id, Name = entity.Department.Name },
				Salary = entity.Salary,
				Shift = new ShiftDTO { Id = entity.Shift.Id, Name = entity.Shift.Name }
			};
		}


		public override Employee MapToEntity(EmployeeDTO dto)
		{
			return new Employee
			{
				Id = dto.Id,
				ApplicationUser = new ApplicationUser
				{
					Id = dto.ApplicationUserId.ToString(),
					Address = new Address() // Boş bir Address nesnesi başlatılıyor
				},
				Title = new EmployeeTitle { Id = dto.Title.Id, Name = dto.Title.Name },
				DepartmentId = dto.DepartmentId,
				Department = new Department { Id = dto.Department.Id, Name = dto.Department.Name },
				Salary = dto.Salary,
				Shift = new Shift { Id = dto.Shift.Id, Name = dto.Shift.Name }
			};
		}

	}
}
