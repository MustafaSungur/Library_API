using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class EmployeeManager : GenericManager<Employee, libAPIContext>, IEmployeeService
	{
		public EmployeeManager(IRepository<Employee, libAPIContext> repository) : base(repository)
		{
		}
	}
}
