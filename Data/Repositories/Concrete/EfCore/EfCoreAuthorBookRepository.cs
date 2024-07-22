using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreAuthorBookRepository : EfCoreGenericRepository<AuthorBook, libAPIContext, int>, IAuthorBookRepository
	{
		public EfCoreAuthorBookRepository(libAPIContext context) : base(context)
		{
		}
	}
}
