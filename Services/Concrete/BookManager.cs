using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class BookManager : GenericManager<Book, libAPIContext>, IBookService
	{
		public BookManager(IRepository<Book, libAPIContext> repository) : base(repository)
		{
		}
	}
}
