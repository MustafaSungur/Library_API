using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class LocationManager : GenericManager<Location, libAPIContext>, ILocationService
	{
		public LocationManager(IRepository<Location, libAPIContext> repository) : base(repository)
		{
		}
	}
}
