using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class SubCategoryManager : GenericManager<SubCategory, libAPIContext>, ISubCategoryService
	{
		public SubCategoryManager(IRepository<SubCategory, libAPIContext> repository) : base(repository)
		{
		}
	}
}
