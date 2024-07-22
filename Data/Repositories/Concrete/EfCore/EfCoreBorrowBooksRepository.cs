using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreBorrowBooksRepository : EfCoreGenericRepository<BorrowBooks, libAPIContext, int>, IBorrowBooksRepository
	{
		public EfCoreBorrowBooksRepository(libAPIContext context) : base(context)
		{
		}

		public async Task<BorrowBooks> GetMemberIdAndBookIdAsync(string memberId, int bookId)
		{
			return await _context.BorrowBooks
				.FirstOrDefaultAsync(bb => bb.MemberId == memberId && bb.BookId == bookId);
		}

		public override async Task<BorrowBooks?> GetByIdAsync(int id)
		{
			return await _context.BorrowBooks
				.AsTracking()
				.Include(bh => bh.Book)
					.ThenInclude(b => b.AuthorBooks)
						.ThenInclude(ab => ab.Author)
				.Include(bh => bh.Book)
					.ThenInclude(b => b.LanguageBooks)
						.ThenInclude(lb => lb.Language)
				.Include(bh => bh.Book)
					.ThenInclude(b => b.SubCategoryBooks)
						.ThenInclude(sb => sb.SubCategory)
				.Include(bh => bh.Book).ThenInclude(b=>b.Stock)
				.Include(bh => bh.Member)
					.ThenInclude(m => m.ApplicationUser)
						.ThenInclude(au => au.Address)
							.ThenInclude(a => a.Country)
				.Include(bh => bh.Member)
					.ThenInclude(m => m.ApplicationUser)
						.ThenInclude(au => au.Address)
							.ThenInclude(a => a.City)
				.FirstOrDefaultAsync(bb => bb.Id == id);
		}

		public override async Task<IEnumerable<BorrowBooks>> GetAllAsync()
		{
			return await _context.BorrowBooks
				.AsTracking()
				.Include(bh => bh.Book)
					.ThenInclude(b => b.AuthorBooks)
						.ThenInclude(ab => ab.Author)
				.Include(bh => bh.Book)
					.ThenInclude(b => b.LanguageBooks)
						.ThenInclude(lb => lb.Language)
				.Include(bh => bh.Book)
					.ThenInclude(b => b.SubCategoryBooks)
						.ThenInclude(sb => sb.SubCategory)
				.Include(bh => bh.Book)
					.ThenInclude(b => b.Stock)
				.Include(bh => bh.Member)
					.ThenInclude(m => m.ApplicationUser)
						.ThenInclude(au => au.Address)
							.ThenInclude(a => a.Country)
				.Include(bh => bh.Member)
					.ThenInclude(m => m.ApplicationUser)
						.ThenInclude(au => au.Address)
							.ThenInclude(a => a.City)
				.ToListAsync();
		}
	}
}
