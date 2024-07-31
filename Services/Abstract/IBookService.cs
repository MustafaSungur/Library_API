using System.Threading.Tasks;
using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IBookService:IService<Book, BookCreateDTO,BookReadDTO, libAPIContext,int>
	{
		Task<string> RateBook(int BookId,short Rate,string userEmail);
		Task<Stock> UpdateStockAsync(string ISBM, int totalCopies, List<int>? bookIdsToRemove = null);
	}
}
