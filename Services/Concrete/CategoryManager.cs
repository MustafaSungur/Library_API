using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class CategoryManager : GenericManager<Category, CategoryDTO, libAPIContext,int>, ICategoryService
	{
		public CategoryManager(IRepository<Category, libAPIContext,int> repository) : base(repository)
		{
		}

		protected override Category MapToEntity(CategoryDTO dto)
		{
			return new Category
			{
				Id = dto.Id,
				Name = dto.Name,
				SubCategories = dto.SubCategories?.Select(sc => new SubCategory
				{
					Id = sc.Id,
					Name = sc.Name,
					CategoryId = sc.CategoryId
				}).ToList()
			};
		}

		protected override CategoryDTO MapToDto(Category entity)
		{
			return new CategoryDTO
			{
				Id = entity.Id,
				Name = entity.Name,
				SubCategories = entity.SubCategories?.Select(sc => new SubCategoryDTO
				{
					Id = sc.Id,
					Name = sc.Name,
					CategoryId = sc.CategoryId
				}).ToList()

			}
		}
