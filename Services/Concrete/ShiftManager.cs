using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class ShiftManager : GenericManager<Shift, ShiftDTO, libAPIContext,int>, IShiftService
	{
		public ShiftManager(IRepository<Shift, libAPIContext,int> repository) : base(repository)
		{
		}

		protected override Shift MapToEntity(ShiftDTO dto)
		{
			return new Shift
			{
				Id = dto.Id,
				Name = dto.Name
			};
		}

		protected override ShiftDTO MapToDto(Shift entity)
		{
			return new ShiftDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}

	}
}
