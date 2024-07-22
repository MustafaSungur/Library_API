using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IAuthorService:IService<Author, AuthorCreateDTO, AuthorReadDTO, libAPIContext,long>
	{
	}
}
