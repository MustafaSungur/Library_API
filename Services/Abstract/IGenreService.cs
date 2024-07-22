using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IGenreService:IService<Genre, GenreCreateDTO, GenreReadDTO, libAPIContext, short>
	{
	}
}
