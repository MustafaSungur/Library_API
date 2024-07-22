using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface ILocationService:IService<Location, LocationCreateDTO, LocationReadDTO, libAPIContext,int>
	{
	}
}
