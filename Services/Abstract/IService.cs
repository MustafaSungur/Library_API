using Microsoft.EntityFrameworkCore;

namespace libAPI.Services.Abstract
{
	public interface IService<TEntity, TContext>
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
