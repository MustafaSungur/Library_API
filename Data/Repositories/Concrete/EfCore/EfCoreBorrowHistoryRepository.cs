using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreBorrowHistoryRepository : EfCoreGenericRepository<BorrowHistory, libAPIContext, int>, IBorrowHistoryRepository
	{
		public EfCoreBorrowHistoryRepository(libAPIContext context) : base(context)
		{
		}

		public async Task<BorrowHistory> GetByMemberAndBookAsync(string memberId, int bookId)
		{
			return await _context.BorrowHistories
				.FirstOrDefaultAsync(b => b.MemberId == memberId && b.BookId == bookId && !b.IsReturned);
		}

		public async Task<List<BorrowHistory>> GetAllByMemberIdAsync(string memberId)
		{
			return await _context.BorrowHistories
				.AsTracking()
				.Include(bh => bh.Book)
					.ThenInclude(b => b.AuthorBooks)
						.ThenInclude(ab => ab.Author)
				.Include(bh => bh.Book)
					.ThenInclude(b => b.LanguageBooks)
						.ThenInclude(lb => lb.Language)
				.Include(bh => bh.Book)
					.ThenInclude(b => b.Stock)
				.Include(bh => bh.Book)
					.ThenInclude(b => b.SubCategoryBooks)
						.ThenInclude(sb => sb.SubCategory)
				.Include(bh => bh.BorrowingEmployee)
					.ThenInclude(e => e.ApplicationUser)
				.Include(bh => bh.LendingEmployee)
					.ThenInclude(e => e.ApplicationUser)
				.Where(b => b.MemberId == memberId)
				.ToListAsync();
		}



		public override async Task<BorrowHistory?> GetByIdAsync(int id)
		{
			return await _context.BorrowHistories
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
				.Include(bh => bh.BorrowingEmployee)
					.ThenInclude(e => e.ApplicationUser)
				.Include(bh => bh.LendingEmployee)
					.ThenInclude(e => e.ApplicationUser)
				.FirstOrDefaultAsync(bh => bh.Id == id);
		}

		public override async Task<IEnumerable<BorrowHistory>> GetAllAsync()
		{
			return await _context.BorrowHistories
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
					.ThenInclude(b=>b.Stock)
				.Include(bh => bh.Member)
					.ThenInclude(m => m.ApplicationUser)
						.ThenInclude(au => au.Address)
							.ThenInclude(a => a.Country)
				.Include(bh => bh.Member)
					.ThenInclude(m => m.ApplicationUser)
						.ThenInclude(au => au.Address)
							.ThenInclude(a => a.City)
				.Include(bh => bh.BorrowingEmployee)
					.ThenInclude(e => e.ApplicationUser)
				.Include(bh => bh.LendingEmployee)
					.ThenInclude(e => e.ApplicationUser)

				.ToListAsync();
		}
	}
}
