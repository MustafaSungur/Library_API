using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, libAPIContext>,ICategoryRepository
	{
		public EfCoreCategoryRepository(libAPIContext context) : base(context)
		{
		}
	}
}
