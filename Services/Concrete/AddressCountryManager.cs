using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AddressCountryManager : GenericManager<AddressCountry, libAPIContext>, IAddressCountryService
	{
		public AddressCountryManager(IRepository<AddressCountry, libAPIContext> repository) : base(repository)
		{
		}
	}
}
