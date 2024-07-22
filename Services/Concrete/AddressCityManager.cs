using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
namespace libAPI.Services.Concrete
{
	public class AddressCityManager : GenericManager<AddressCity, AddressCityCreateDTO, AddressCityReadDTO, libAPIContext, short>, IAddressCityService
	{
		public AddressCityManager(IRepository<AddressCity, libAPIContext, short> repository) : base(repository)
		{
		}

		public override AddressCity MapToEntity(AddressCityCreateDTO dto)
		{
			return new AddressCity
			{
				Name = dto.Name
			};
		}

		public override AddressCityReadDTO MapToDto(AddressCity entity)
		{
			return new AddressCityReadDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}
	}
}
