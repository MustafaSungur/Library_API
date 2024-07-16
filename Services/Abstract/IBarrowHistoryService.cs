using libAPI.Data;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IBarrowHistoryService : IService<BorrowHistory, libAPIContext, int>
	{

		Task<BorrowHistory> GetByMemberAndBookAsync(string memberId, int bookId);


	}


}
