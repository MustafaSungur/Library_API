using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IBarrowHistoryService : IService<BorrowHistory, BorrowHistoryDTO, libAPIContext, int>
	{

		Task<BorrowHistory> GetByMemberAndBookAsync(string memberId, int bookId);


	}


}
