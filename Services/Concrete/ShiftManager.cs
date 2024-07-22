using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class ShiftManager : GenericManager<Shift, ShiftCreateDTO, ShiftReadDTO, libAPIContext, short>, IShiftService
	{
		public ShiftManager(IRepository<Shift, libAPIContext, short> repository) : base(repository)
		{
		}

		public override Shift MapToEntity(ShiftCreateDTO dto)
		{
			return new Shift
			{
				Name = dto.Name
			};
		}

		public override ShiftReadDTO MapToDto(Shift entity)
		{
			return new ShiftReadDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}


		public override ShiftCreateDTO MapToCreateDto(ShiftReadDTO entity)
		{
			return new ShiftCreateDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}
	}
}
