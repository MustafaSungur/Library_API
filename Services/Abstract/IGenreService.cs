using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IGenreService:IService<Genre, GenreDTO, libAPIContext,int>
	{
	}
}
