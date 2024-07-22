using System.Net;
using System.Threading.Tasks;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreStockRepository : EfCoreGenericRepository<Stock, libAPIContext, string>, IStockRepository
	{
		public EfCoreStockRepository(libAPIContext context) : base(context)
		{
		}

		


	}
}
