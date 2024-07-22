using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class SubcategoryBookManager : GenericManager<SubCategoryBook, SubCategoryBookCreateDTO, SubCategoryBookReadDTO, libAPIContext, int>, ISubcategoryBookService
	{
		public SubcategoryBookManager(IRepository<SubCategoryBook, libAPIContext, int> repository) : base(repository)
		{
		}

		public override SubCategoryBook MapToEntity(SubCategoryBookCreateDTO dto)
		{
			return new SubCategoryBook
			{
				BookId = dto.BookId,
				SubCategoryId = dto.SubCategoryId
			};
		}

		public override SubCategoryBookReadDTO MapToDto(SubCategoryBook entity)
		{
			return new SubCategoryBookReadDTO
			{
				BookId = entity.BookId,
				SubCategoryId = entity.SubCategoryId,
			
			};
		}
	}
}
