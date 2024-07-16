using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AddressCityManager : GenericManager<AddressCity, AddressCityDTO, libAPIContext,int>, IAddressCityService
	{
		public AddressCityManager(IRepository<AddressCity, libAPIContext,int> repository) : base(repository)
		{
		}

		protected override AddressCity MapToEntity(AddressCityDTO dto)
		{
			return new AddressCity
			{
				Id = dto.Id,
				Name = dto.Name
			};
		}

		protected override AddressCityDTO MapToDto(AddressCity entity)
		{
			return new AddressCityDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}
	}
}
