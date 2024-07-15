using libAPI.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.data.Concrete.EfCore
{
	public class EfCoreGenericRepository<TEntity, TContext> : IRepository<TEntity, TContext>
	   where TEntity : class
	   where TContext : DbContext
	{
		protected readonly TContext _context;

		public EfCoreGenericRepository(TContext context)
		{
			_context = context;
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await _context.Set<TEntity>().FindAsync(id);
			if (entity == null)
			{
				return false;
			}

			_context.Set<TEntity>().Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity?> GetByIdAsync(int id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}