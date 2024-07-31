using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreLanguageBookRepository : EfCoreGenericRepository<LanguageBook, libAPIContext, int>, ILanguageBookRepository
	{
		public EfCoreLanguageBookRepository(libAPIContext context) : base(context)
		{
		}

		public async Task RemoveAsync(LanguageBook languageBook)
		{
			_context.LanguageBooks.Remove(languageBook);
			await _context.SaveChangesAsync();
		}

		public async Task<List<LanguageBook>> FindByBookIdAsync(int bookId)
		{
			return await _context
								 .LanguageBooks.Where(lb => lb.BookId == bookId)
								 .ToListAsync();
		}
	}
}
