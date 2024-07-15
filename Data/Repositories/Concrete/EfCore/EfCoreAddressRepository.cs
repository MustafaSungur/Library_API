using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreAddressRepository : EfCoreGenericRepository<Address, libAPIContext,int>,IAddressRepository
	{
		public EfCoreAddressRepository(libAPIContext context) : base(context)
		{
		}
	}
}
