using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AddressCityManager : GenericManager<AddressCity, libAPIContext,int>, IAddressCityService
	{
		public AddressCityManager(IRepository<AddressCity, libAPIContext,int> repository) : base(repository)
		{
		}
	}
}
