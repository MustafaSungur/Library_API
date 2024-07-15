using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreEmployeeTitleRepository : EfCoreGenericRepository<EmployeeTitle, libAPIContext>,IEmployeeTitleRepository
	{
		public EfCoreEmployeeTitleRepository(libAPIContext context) : base(context)
		{
		}

		
    }
}
