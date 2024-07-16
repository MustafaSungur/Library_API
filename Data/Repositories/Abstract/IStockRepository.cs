using libAPI.Models;

namespace libAPI.Data.Repositories.Abstract
{
	public interface IStockRepository: IRepository<Stock, libAPIContext, int>
	{
		Task<Stock> GetStockByBookIdAsync(int id);

	}

}
