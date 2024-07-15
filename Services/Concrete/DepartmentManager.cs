using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class DepartmentManager : GenericManager<Department, libAPIContext>, IDepartmentsService
	{
		public DepartmentManager(IRepository<Department, libAPIContext> repository) : base(repository)
		{
		}
	}
}
