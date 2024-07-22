using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IAddressService:IService<Address, AddressCreateDTO, AddressReadDTO, libAPIContext,int>
	{
		void DetachEntity(Address address);
	}
}
