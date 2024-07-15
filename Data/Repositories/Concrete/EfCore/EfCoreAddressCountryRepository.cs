using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreAddressCountryRepository : EfCoreGenericRepository<AddressCountry, libAPIContext>,IAddressCountryRepository
	{
		public EfCoreAddressCountryRepository(libAPIContext context) : base(context)
		{

		}
	}
}

