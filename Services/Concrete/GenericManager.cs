using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace libAPI.Services.Concrete
{
	public class GenericManager<TEntity, TContext, TId> : IService<TEntity, TContext, TId>
		where TEntity : class
		where TContext : DbContext
	{
		protected readonly IRepository<TEntity, TContext, TId> _repository;

		public GenericManager(IRepository<TEntity, TContext, TId> repository)
		{
			_repository = repository;
		}

		public IRepository<EmployeeTitle, libAPIContext, int> Repository { get; }

		public virtual Task<TEntity> AddAsync(TEntity entity)
		{
			return _repository.AddAsync(entity);
		}

		public virtual Task<bool> DeleteAsync(TId id)
		{
			return _repository.DeleteAsync(id);
		}
			
		public Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return _repository.GetAllAsync();
		}

		public Task<TEntity?> GetByIdAsync(TId id)
		{
			return _repository.GetByIdAsync(id);
		}

		public Task<TEntity> UpdateAsync(TEntity entity)
		{
			return _repository.UpdateAsync(entity);
		}
	}
}
