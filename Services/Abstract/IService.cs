using Microsoft.EntityFrameworkCore;

namespace libAPI.Services.Abstract
{
	public interface IService<TEntity, TDto, TContext, TId>
		where TEntity : class
		where TDto : class
		where TContext : DbContext
	{
		Task<TDto> AddAsync(TDto dto);
		Task<bool> DeleteAsync(TId id);
		Task<IEnumerable<TDto>> GetAllAsync();
		Task<TDto?> GetByIdAsync(TId id);
		Task<TDto> UpdateAsync(TDto dto);
	}
}
