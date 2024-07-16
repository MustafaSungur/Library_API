using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface ILanguageService:IService<Language, LanguageDTO ,libAPIContext,string>
	{
	}
}
