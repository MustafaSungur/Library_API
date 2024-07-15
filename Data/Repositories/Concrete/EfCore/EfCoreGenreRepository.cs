using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreGenreRepository : EfCoreGenericRepository<Genre, libAPIContext,int>,IGenreRepository
	{
		public EfCoreGenreRepository(libAPIContext context) : base(context)
		{
		}
	}
}
