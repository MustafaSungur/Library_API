using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete
{
	public class EFCoreAddressCityRepository : EfCoreGenericRepository<AddressCity, libAPIContext,short>,IAddressCityRepository
	{
		public EFCoreAddressCityRepository(libAPIContext context) : base(context)
		{
		}
	}
}
