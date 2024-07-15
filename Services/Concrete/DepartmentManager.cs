using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class DepartmentManager : GenericManager<Department, libAPIContext,int>, IDepartmentsService
	{
		public DepartmentManager(IRepository<Department, libAPIContext,int> repository) : base(repository)
		{
		}
	}
}
