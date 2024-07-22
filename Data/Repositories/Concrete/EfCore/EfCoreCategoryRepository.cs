using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, libAPIContext, short>, ICategoryRepository
	{
		public EfCoreCategoryRepository(libAPIContext context) : base(context)
		{
		}

		public override async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await _context.Category
				   .Include(c => c.SubCategories)
						.ThenInclude(c=>c.SubCategoryBooks)
				   .ToListAsync();
		}

		public override async Task<Category?> GetByIdAsync(short id)
		{
			return await _context.Category.Include(c => c.SubCategories)
						.ThenInclude(c => c.SubCategoryBooks)
						.FirstOrDefaultAsync(c => c.Id == id);
		}
	}
}
