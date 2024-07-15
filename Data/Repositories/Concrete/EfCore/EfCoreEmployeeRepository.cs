using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreEmployeeRepository : EfCoreGenericRepository<Employee, libAPIContext>,IEmployeeRepository
	{
		public EfCoreEmployeeRepository(libAPIContext context) : base(context)
		{
		}
	}
}
