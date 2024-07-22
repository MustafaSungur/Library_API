using libAPI.Models;

namespace libAPI.Data.Repositories.Abstract
{
	public interface ICategoryRepository:IRepository<Category, libAPIContext, short>
	{
		Task<Category?> GetByIdAsync(short id);
		Task<IEnumerable<Category>> GetAllAsync();
	}
}
