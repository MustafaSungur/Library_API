using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class BookManager : GenericManager<Book, libAPIContext,int>, IBookService
	{
		public BookManager(IRepository<Book, libAPIContext,int> repository) : base(repository)
		{
		}
	}
}
