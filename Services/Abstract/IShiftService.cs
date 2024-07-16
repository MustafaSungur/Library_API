using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IShiftService:IService<Shift, ShiftDTO, libAPIContext,int>
	{
	}
}
