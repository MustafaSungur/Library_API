using Microsoft.EntityFrameworkCore;

namespace libAPI.Data.Repositories.Abstract
{
	public interface IRepository<TEntity, TContext>
	   where TEntity : class
	   where TContext : DbContext
	{
		Task<TEntity> AddAsync(TEntity entity);
		Task<bool> DeleteAsync(int id);
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity?> GetByIdAsync(int id);
		Task<TEntity> UpdateAsync(TEntity entity);
	}
}
