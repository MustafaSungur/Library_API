using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AddressManager : GenericManager<Address, libAPIContext,int>, IAddressService
	{
		public AddressManager(IRepository<Address, libAPIContext,int> repository) : base(repository)
		{
		}
	}
}
