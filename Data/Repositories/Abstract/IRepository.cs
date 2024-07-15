using Microsoft.EntityFrameworkCore;

namespace libAPI.Data.Repositories.Abstract
{
	public interface IRepository<TEntity, TContext, TId>
	  where TEntity : class
	  where TContext : DbContext
	{
		Task<TEntity> AddAsync(TEntity entity);
		Task<bool> DeleteAsync(TId id);
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity?> GetByIdAsync(TId id);
		Task<TEntity> UpdateAsync(TEntity entity);
	}
}
