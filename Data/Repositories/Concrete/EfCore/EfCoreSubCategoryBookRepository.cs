using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreSubCategoryBookRepository : EfCoreGenericRepository<SubCategoryBook, libAPIContext, int>,ISubCategoryBookRepository
	{
	
		public EfCoreSubCategoryBookRepository(libAPIContext context) : base(context)
		{
			
		}

		public async Task RemoveAsync(SubCategoryBook subCategoryBook)
		{
			_context.SubCategoryBooks.Remove(subCategoryBook);
			await _context.SaveChangesAsync();
		}

		public async Task<List<SubCategoryBook>> FindByBookIdAsync(int bookId)
		{
			return await _context.SubCategoryBooks
								 .Where(scb => scb.BookId == bookId)
								 .ToListAsync();
		}
	}
}
