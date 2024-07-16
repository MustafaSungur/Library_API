using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
	public class BorrowHistoryManager : GenericManager<BorrowHistory, libAPIContext, int>, IBarrowHistoryService
	{
		public BorrowHistoryManager(IRepository<BorrowHistory, libAPIContext, int> repository) : base(repository)
		{
		}

	
		public async Task<BorrowHistory> GetByMemberAndBookAsync(string memberId, int bookId) {

			return await ((IBorrowHistoryRepository)_repository).GetByMemberAndBookAsync(memberId, bookId);

		}

	}
}
