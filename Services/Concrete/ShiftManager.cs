using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class ShiftManager : GenericManager<Shift, libAPIContext>, IShiftService
	{
		public ShiftManager(IRepository<Shift, libAPIContext> repository) : base(repository)
		{
		}
	}
}
