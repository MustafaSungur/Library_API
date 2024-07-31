using libAPI.Models;

namespace libAPI.Data.Repositories.Abstract
{
	public interface IAuthorBookRepository : IRepository<AuthorBook, libAPIContext, int>
	{
		Task RemoveAsync(AuthorBook authorBook);
		Task<List<AuthorBook>> FindByBookIdAsync(int bookId);
	}


}
