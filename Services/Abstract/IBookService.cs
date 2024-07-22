using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IBookService:IService<Book, BookCreateDTO,BookReadDTO, libAPIContext,int>
	{
	}
}
