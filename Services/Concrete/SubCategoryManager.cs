using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
	public class SubCategoryManager : GenericManager<SubCategory, SubCategoryCreateDTO, SubCategoryReadDTO, libAPIContext, short>, ISubCategoryService
	{

		public SubCategoryManager(ISubCategoryRepository repository) : base(repository)
		{
		}

		

		public override SubCategory MapToEntity(SubCategoryCreateDTO dto)
		{
			return new SubCategory
			{
				Name = dto.Name,
				CategoryId = dto.CategoryId
			};
		}

		public override SubCategoryReadDTO MapToDto(SubCategory entity)
		{
			return new SubCategoryReadDTO
			{
				Id = entity.Id,
				Name = entity.Name,
				Category = entity.Category != null ? new CategoryReadDTO
				{
					Id = entity.Category.Id,
					Name = entity.Category.Name
				} : null
			};
		}

		public override SubCategoryCreateDTO MapToCreateDto(SubCategoryReadDTO dto)
		{
			return new SubCategoryCreateDTO
			{
				Name = dto.Name,
				CategoryId = dto.Category.Id
			};
		}
	}
}
