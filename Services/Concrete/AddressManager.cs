using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AddressManager : GenericManager<Address, libAPIContext>, IAddressService
	{
		public AddressManager(IRepository<Address, libAPIContext> repository) : base(repository)
		{
		}
	}
}
