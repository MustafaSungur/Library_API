using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreAuthorBookRepository : EfCoreGenericRepository<AuthorBook, libAPIContext, int>, IAuthorBookRepository
	{
		public EfCoreAuthorBookRepository(libAPIContext context) : base(context)
		{
		}

		public async Task RemoveAsync(AuthorBook authorBook)
		{
			_context.Remove(authorBook);
			await _context.SaveChangesAsync();
		}

		public async Task<List<AuthorBook>> FindByBookIdAsync(int bookId)
		{
			return await _context
								 .AuthorBooks.Where(lb => lb.BookId == bookId)
								 .ToListAsync();
		}

	}
}
