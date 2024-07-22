using libAPI.Data.Repositories.Abstract;
using libAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
	public class GenericManager<TEntity, TDtoCreate, TDtoRead, TContext, TId> : IService<TEntity, TDtoCreate, TDtoRead, TContext, TId>
		where TEntity : class
		where TDtoCreate : class
		where TDtoRead : class
		where TContext : DbContext
	{
		protected readonly IRepository<TEntity, TContext, TId> _repository;

		public GenericManager(IRepository<TEntity, TContext, TId> repository)
		{
			_repository = repository;
		}

		public virtual async Task<TDtoRead> AddAsync(TDtoCreate dto)
		{
			var entity = MapToEntity(dto);
			await _repository.AddAsync(entity);
			return MapToDto(entity);
		}

		public virtual async Task<bool> DeleteAsync(TId id)
		{
			return await _repository.DeleteAsync(id);
		}

		public virtual async Task<IEnumerable<TDtoRead>> GetAllAsync()
		{
			var entities = await _repository.GetAllAsync();
			return entities.Select(e => MapToDto(e)).ToList();
		}

		public virtual async Task<TDtoRead?> GetByIdAsync(TId id)
		{
			var entity = await _repository.GetByIdAsync(id);
			return entity == null ? null : MapToDto(entity);
		}

		public virtual async Task<TDtoRead> UpdateAsync(TDtoCreate dto)
		{
			var entity = MapToEntity(dto);
			await _repository.UpdateAsync(entity);
			return MapToDto(entity);
		}

		public virtual TEntity MapToEntity(TDtoCreate dto)
		{
			throw new NotImplementedException();
		}

		public virtual TDtoRead MapToDto(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public virtual TDtoCreate MapToCreateDto(TDtoRead entity)
		{
			throw new NotImplementedException();
		}
	}
}
