using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreDepartmentRepository : EfCoreGenericRepository<Department, libAPIContext>,IDepartmentRepository
	{
		public EfCoreDepartmentRepository(libAPIContext context) : base(context)
		{
		}
	}
}
