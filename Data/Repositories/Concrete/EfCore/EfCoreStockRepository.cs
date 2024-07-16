using System.Net;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreStockRepository : EfCoreGenericRepository<Stock, libAPIContext, int>, IStockRepository
	{
		public EfCoreStockRepository(libAPIContext context) : base(context)
		{
		}

		public async Task<Stock> GetStockByBookIdAsync(int id)
		{
			return await _context.Stocks.FirstOrDefaultAsync(s => s.BookId == id);
		}

	}
}
