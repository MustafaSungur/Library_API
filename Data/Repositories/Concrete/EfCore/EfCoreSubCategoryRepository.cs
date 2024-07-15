using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreSubCategoryRepository : EfCoreGenericRepository<SubCategory, libAPIContext,int>,ISubCategoryRepository
	{
		public EfCoreSubCategoryRepository(libAPIContext context) : base(context)
		{
		}
	}
}
