using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class SubCategoryManager : GenericManager<SubCategory, SubCategoryDTO, libAPIContext,int>, ISubCategoryService
	{
		public SubCategoryManager(IRepository<SubCategory, libAPIContext,int> repository) : base(repository)
		{
		}

		protected override SubCategory MapToEntity(SubCategoryDTO dto)
		{
			return new SubCategory
			{
				Id = dto.Id,
				Name = dto.Name,
				CategoryId = dto.CategoryId,
				Category = new Category
				{
					Id = dto.CategoryId,
					Name = dto.Name 
				}
			};
		}

		protected override SubCategoryDTO MapToDto(SubCategory entity)
		{
			return new SubCategoryDTO
			{
				Id = entity.Id,
				Name = entity.Name,
				CategoryId = entity.CategoryId
				
			};
		}

	}
}
