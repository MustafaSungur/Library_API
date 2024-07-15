
using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AuthorManager : GenericManager<Author, libAPIContext,int>, IAuthorService
	{
		public AuthorManager(IRepository<Author, libAPIContext,int> repository) : base(repository)
		{
		}
	}
}
