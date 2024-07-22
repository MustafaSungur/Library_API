using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface ISubCategoryService:IService<SubCategory, SubCategoryCreateDTO, SubCategoryReadDTO, libAPIContext,short>
	{
	}
}
