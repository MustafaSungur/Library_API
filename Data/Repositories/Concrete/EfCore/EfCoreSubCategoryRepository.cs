using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreSubCategoryRepository : EfCoreGenericRepository<SubCategory, libAPIContext, short>, ISubCategoryRepository
	{
		public EfCoreSubCategoryRepository(libAPIContext context) : base(context)
		{
		}

		public override async Task<IEnumerable<SubCategory>> GetAllAsync()
		{
			return await _context.SubCategory.Include(sc => sc.Category).Include(sc => sc.SubCategoryBooks).ToListAsync();
			
        }

		public override async Task<SubCategory?> GetByIdAsync(short id)
		{
			return await _context.SubCategory.Include(sc => sc.Category).Include(sc => sc.SubCategoryBooks).FirstOrDefaultAsync(sc => sc.Id == id);
		

		}


		

	}


}
