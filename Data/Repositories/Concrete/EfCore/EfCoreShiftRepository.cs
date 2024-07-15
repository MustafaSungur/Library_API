using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreShiftRepository : EfCoreGenericRepository<Shift, libAPIContext,int>,IShiftRepository
	{
		public EfCoreShiftRepository(libAPIContext context) : base(context)
		{
		}
	}
}
