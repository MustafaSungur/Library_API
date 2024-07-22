using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IBorrowHistoryService : IService<BorrowHistory, BorrowHistoryCreateDTO, BorrowHistoryReadDTO, libAPIContext, int>
	{

		Task<BorrowHistoryReadDTO> GetByMemberAndBookAsync(string memberId, int bookId);
		Task<List<BorrowHistoryReadDTO>> GetAllByMemberIdAsync(string memberId);

	}


}
