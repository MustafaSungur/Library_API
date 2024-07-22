using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IAuthorBookService: IService<AuthorBook, AuthorBookCreateDTO, AuthorBookReadDTO, libAPIContext, int>
	{
	}
}
