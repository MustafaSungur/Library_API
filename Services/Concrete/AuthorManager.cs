
using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AuthorManager : GenericManager<Author, libAPIContext>, IAuthorService
	{
		public AuthorManager(IRepository<Author, libAPIContext> repository) : base(repository)
		{
		}
	}
}
