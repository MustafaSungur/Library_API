using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class EmployeeTitleManager : GenericManager<EmployeeTitle, libAPIContext>, IEmployeeTitleService
	{
		public EmployeeTitleManager(IRepository<EmployeeTitle, libAPIContext> repository) : base(repository)
		{
		}
	}
}
