using libAPI.Models;

namespace libAPI.Data.Repositories.Abstract
{
	public interface IBookRepository:IRepository<Book, libAPIContext,int>
	{
		Task<IEnumerable<Book>> GetByIsbmAsync(string ISBM);
	}
}
