using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface ILanguageBookService: IService<LanguageBook, LanguageBookCreateDTO,LanguageBookReadDTO, libAPIContext, int>
	{
	}
}
