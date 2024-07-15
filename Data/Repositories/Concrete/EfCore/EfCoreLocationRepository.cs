using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreLocationRepository : EfCoreGenericRepository<Location, libAPIContext,int>,ILocationRepository
	{
		public EfCoreLocationRepository(libAPIContext context) : base(context)
		{
		}
	}
}
