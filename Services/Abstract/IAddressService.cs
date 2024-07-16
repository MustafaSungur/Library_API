using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IAddressService:IService<Address, AddressDTO, libAPIContext,int>
	{
	}
}
