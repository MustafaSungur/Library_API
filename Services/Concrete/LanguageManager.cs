using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class LanguageManager : GenericManager<Language, libAPIContext>, ILanguageService
	{
		public LanguageManager(IRepository<Language, libAPIContext> repository) : base(repository)
		{
		}
	}
}

