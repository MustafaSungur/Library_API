using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class CategoryManager : GenericManager<Category, libAPIContext,int>, ICategoryService
	{
		public CategoryManager(IRepository<Category, libAPIContext,int> repository) : base(repository)
		{
		}
	}
}
