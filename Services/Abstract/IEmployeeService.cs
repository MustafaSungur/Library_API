using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IEmployeeService : IService<Employee, EmployeeCreateDTO, EmployeeReadDTO, libAPIContext, string>
	{
		Task<EmployeeReadDTO> UpdateAsync(string employeeId, EmployeeCreateDTO dto);
	}
}
