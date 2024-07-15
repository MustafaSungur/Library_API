using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AddressCountryManager : GenericManager<AddressCountry, libAPIContext,int>, IAddressCountryService
	{
		public AddressCountryManager(IRepository<AddressCountry, libAPIContext,int> repository) : base(repository)
		{
		}
	}
}
