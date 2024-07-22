using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class GenreManager : GenericManager<Genre, GenreCreateDTO, GenreReadDTO, libAPIContext, short>, IGenreService
	{
		public GenreManager(IRepository<Genre, libAPIContext, short> repository) : base(repository)
		{
		}

		public override Genre MapToEntity(GenreCreateDTO dto)
		{
			return new Genre
			{
				Name = dto.Name
			};
		}

		public override GenreReadDTO MapToDto(Genre entity)
		{
			return new GenreReadDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}
	}
}
