using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreEducationalDegreeRepository : EfCoreGenericRepository<EducationalDegree, libAPIContext, short>, IEducationalDegreeRepository
	{
		public EfCoreEducationalDegreeRepository(libAPIContext context) : base(context)
		{

		}
	
	}
}
