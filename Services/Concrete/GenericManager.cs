using libAPI.Data.Repositories.Abstract;
using libAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libAPI.Services.Concrete
{
	public class GenericManager<TEntity, TContext> : IService<TEntity, TContext>
		where TEntity : class
		where TContext : DbContext
	{
		private readonly IRepository<TEntity, TContext> _repository;

		public GenericManager(IRepository<TEntity, TContext> repository)
		{
			_repository = repository;
		}

		public Task<TEntity> AddAsync(TEntity entity)
		{
			return _repository.AddAsync(entity);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return _repository.DeleteAsync(id);
		}

		public Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return _repository.GetAllAsync();
		}

		public Task<TEntity?> GetByIdAsync(int id)
		{
			return _repository.GetByIdAsync(id);
		}

		public Task<TEntity> UpdateAsync(TEntity entity)
		{
			return _repository.UpdateAsync(entity);
		}
	}
}
