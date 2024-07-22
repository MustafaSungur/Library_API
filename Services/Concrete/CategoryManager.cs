using System.Linq;
using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class CategoryManager : GenericManager<Category, CategoryCreateDTO, CategoryReadDTO, libAPIContext, short>, ICategoryService
	{
		public CategoryManager(IRepository<Category, libAPIContext, short> repository) : base(repository)
		{
		}

		public override Category MapToEntity(CategoryCreateDTO dto)
		{
			return new Category
			{
				Name = dto.Name,
			};
		}

		public override CategoryReadDTO MapToDto(Category entity)
		{
			return new CategoryReadDTO
			{
				Id = entity.Id,
				Name = entity.Name,
				SubCategories = entity.SubCategories?.Select(sc => new SubCategoryReadDTO
				{
					Id = sc.Id,
					Name = sc.Name,
					
				}).ToList()
			};
		}
		public override CategoryCreateDTO MapToCreateDto(CategoryReadDTO dto)
		{
			return new CategoryCreateDTO
			{
				Name = dto.Name,
				
			};
		}
	}
}
