using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface ISubcategoryBookService: IService<SubCategoryBook, SubCategoryBookCreateDTO, SubCategoryBookReadDTO, libAPIContext, int>
	{
	}
}
