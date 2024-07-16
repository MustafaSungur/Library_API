using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IEmployeeTitleService:IService<EmployeeTitle, EmployeeTitleDTO, libAPIContext,int>
	{
	}
}
