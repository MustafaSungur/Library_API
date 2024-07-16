using System.Security.Cryptography;
using libAPI.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.data.Concrete.EfCore
{
	public class EfCoreGenericRepository<TEntity, TContext, TId> : IRepository<TEntity, TContext, TId>
	   where TEntity : class
	   where TContext : DbContext
	{
		protected readonly TContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public EfCoreGenericRepository(TContext context)
		{
			_context = context;
			_dbSet = _context.Set<TEntity>();
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public virtual async Task<bool> DeleteAsync(TId id)
		{
			var entity = await _dbSet.FindAsync(id);
			if (entity == null)
			{
				return false;
			}
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<TEntity?> GetByIdAsync(TId id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			_dbSet.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
