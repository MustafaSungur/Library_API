using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace libAPI.Services.Abstract
{
	public interface IService<TEntity, TDtoCreate, TDtoRead, TContext, TId>
		where TEntity : class
		where TDtoCreate : class
		where TDtoRead : class
		where TContext : DbContext
	{
		Task<TDtoRead> AddAsync(TDtoCreate dto);
		Task<bool> DeleteAsync(TId id);
		Task<IEnumerable<TDtoRead>> GetAllAsync();
		Task<TDtoRead?> GetByIdAsync(TId id);
		Task<TDtoRead> UpdateAsync(TDtoCreate dto);

		TEntity MapToEntity(TDtoCreate dto);
		TDtoRead MapToDto(TEntity entity);
		TDtoCreate MapToCreateDto(TDtoRead entity);
	}
}
