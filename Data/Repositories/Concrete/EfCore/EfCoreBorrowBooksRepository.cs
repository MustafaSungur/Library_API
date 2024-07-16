using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreBorrowBooksRepository : EfCoreGenericRepository<BorrowBooks, libAPIContext, int>, IBorrowBooksRepository
	{
		public EfCoreBorrowBooksRepository(libAPIContext context) : base(context)
		{
		}
	}
}
