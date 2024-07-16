using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IAddressCityService:IService<AddressCity, AddressCityDTO, libAPIContext,int>
	{
	}
}
