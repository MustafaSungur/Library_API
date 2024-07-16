using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class StockManager : GenericManager<Stock, libAPIContext, int>, IStockService
	{
		public StockManager(IRepository<Stock, libAPIContext, int> repository) : base(repository)
		{
		}

		public async Task<Stock> GetStockByBookIdAsync(int id)
		{
			var stock = await ((IStockRepository)_repository).GetStockByBookIdAsync(id);

			if(stock != null)
			{
				throw new Exception("Stock not found");
			}
			return stock!;
		}
	}
}
