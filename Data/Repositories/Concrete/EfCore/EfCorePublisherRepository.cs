using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCorePublisherRepository : EfCoreGenericRepository<Publisher, libAPIContext,int>,IPublisherRepository
	{
		public EfCorePublisherRepository(libAPIContext context) : base(context)
		{
		}
	}
}
