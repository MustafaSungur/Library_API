using libAPI.Models;

namespace libAPI.Data.Repositories.Abstract
{
	public interface IBorrowHistoryRepository:IRepository<BorrowHistory,libAPIContext,int>
	{
		Task<BorrowHistory> GetByMemberAndBookAsync(string memberId, int bookId);
		Task<List<BorrowHistory>> GetAllByMemberIdAsync(string memberId);


	}

	
}
