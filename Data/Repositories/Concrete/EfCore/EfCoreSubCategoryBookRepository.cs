using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreSubCategoryBookRepository : EfCoreGenericRepository<SubCategoryBook, libAPIContext, int>, ISubCategoryBookRepository
	{
		public EfCoreSubCategoryBookRepository(libAPIContext context) : base(context)
		{
		}
	}
}
