using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class EducationalDegreeManager : GenericManager<EducationalDegree, libAPIContext,int>, IEducationalDegreeService
	{
		public EducationalDegreeManager(IRepository<EducationalDegree, libAPIContext,int> repository) : base(repository)
		{
		}
	}
}
