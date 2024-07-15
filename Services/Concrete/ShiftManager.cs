using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class ShiftManager : GenericManager<Shift, libAPIContext,int>, IShiftService
	{
		public ShiftManager(IRepository<Shift, libAPIContext,int> repository) : base(repository)
		{
		}
	}
}
