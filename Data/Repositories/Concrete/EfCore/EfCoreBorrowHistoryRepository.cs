using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;


namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreBorrowHistoryRepository : EfCoreGenericRepository<BorrowHistory, libAPIContext, int>,IBorrowHistoryRepository
	{
		public EfCoreBorrowHistoryRepository(libAPIContext context) : base(context)
		{
		}

		public async Task<BorrowHistory> GetByMemberAndBookAsync(string memberId, int bookId)
		{
			return await _context.BorrowHistories
		   .FirstOrDefaultAsync(b => b.MemberId == memberId && b.BookId == bookId && !b.IsReturned);
		}
	}
}
