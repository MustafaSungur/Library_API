

using libAPI.Models;

namespace libAPI.Data.Repositories.Abstract
{
	public interface IBorrowBooksRepository: IRepository<BorrowBooks, libAPIContext, int>
	{

		Task<BorrowBooks> GetMemberIdAndBookIdAsync(string memberId, int bookId);

	}
}
