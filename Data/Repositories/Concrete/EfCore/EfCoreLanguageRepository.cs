using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreLanguageRepository : EfCoreGenericRepository<Language, libAPIContext,string>,ILanguageRepository
	{
		public EfCoreLanguageRepository(libAPIContext context) : base(context)
		{
		}

	}
}
