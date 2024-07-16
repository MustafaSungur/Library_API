using libAPI.Data.Repositories.Abstract;
using libAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Services.Concrete
{
	public class GenericManager<TEntity, TDto, TContext, TId> : IService<TEntity, TDto, TContext, TId>
		where TEntity : class
		where TDto : class
		where TContext : DbContext
	{
		protected readonly IRepository<TEntity, TContext, TId> _repository;

		public GenericManager(IRepository<TEntity, TContext, TId> repository)
		{
			_repository = repository;
		}

		public virtual async Task<TDto> AddAsync(TDto dto)
		{
			var entity = MapToEntity(dto);
			await _repository.AddAsync(entity);
			return MapToDto(entity);
		}

		public virtual async Task<bool> DeleteAsync(TId id)
		{
			return await _repository.DeleteAsync(id);
		}

		public virtual async Task<IEnumerable<TDto>> GetAllAsync()
		{
			var entities = await _repository.GetAllAsync();
			return entities.Select(e => MapToDto(e)).ToList();
		}

		public virtual async Task<TDto?> GetByIdAsync(TId id)
		{
			var entity = await _repository.GetByIdAsync(id);
			return entity == null ? null : MapToDto(entity);
		}

		public virtual async Task<TDto> UpdateAsync(TDto dto)
		{
			var entity = MapToEntity(dto);
			await _repository.UpdateAsync(entity);
			return MapToDto(entity);
		}

		// MapToEntity ve MapToDto metodlarını override ederek her serviste özelleştirin
		protected virtual TEntity MapToEntity(TDto dto)
		{
			throw new NotImplementedException();
		}

		protected virtual TDto MapToDto(TEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}
