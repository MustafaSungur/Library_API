using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete
{
	public class EFCoreAddressCityRepository : EfCoreGenericRepository<SubCategory, libAPIContext>,IAddressCityRepository
	{
		public EFCoreAddressCityRepository(libAPIContext context) : base(context)
		{
		}
	}
}
