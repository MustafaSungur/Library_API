using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreLanguageBookRepository : EfCoreGenericRepository<LanguageBook, libAPIContext, int>, ILanguageBookRepository
	{
		public EfCoreLanguageBookRepository(libAPIContext context) : base(context)
		{
		}
	}
}
