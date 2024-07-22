using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IBorrowBooksService : IService<BorrowBooks, BorrowBooksCreateDTO, BorrowBooksReadDTO, libAPIContext, int>
	{
		Task<IEnumerable<BorrowBooksReadDTO>> AddListAsync(BorrowBooksCreateDTO borrowBookDto);
	}
}
