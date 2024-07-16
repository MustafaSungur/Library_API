using libAPI.Data;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IStockService:IService<Stock, libAPIContext,int>
	{
		Task<Stock> GetStockByBookIdAsync(int id);
	}
	
}
