using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreAuthorRepository : EfCoreGenericRepository<Author, libAPIContext>,IAuthorRepository
	{
		public EfCoreAuthorRepository(libAPIContext context) : base(context)
		{
		}
	}
}
