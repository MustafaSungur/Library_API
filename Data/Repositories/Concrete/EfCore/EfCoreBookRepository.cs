using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreBookRepository : EfCoreGenericRepository<Book, libAPIContext,int>,IBookRepository
	{
		public EfCoreBookRepository(libAPIContext context) : base(context)
		{
		}
	}
}
