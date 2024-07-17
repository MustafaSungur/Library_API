using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class GenreManager : GenericManager<Genre, GenreDTO, libAPIContext,int>, IGenreService
	{
		public GenreManager(IRepository<Genre, libAPIContext,int> repository) : base(repository)
		{
		}

		public override Genre MapToEntity(GenreDTO dto)
		{
			return new Genre
			{
				Id = dto.Id,
				Name = dto.Name
			};
		}

		public override GenreDTO MapToDto(Genre entity)
		{
			return new GenreDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}

	}
}
