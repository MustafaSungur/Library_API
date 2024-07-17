using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AddressManager : GenericManager<Address, AddressDTO, libAPIContext,int>, IAddressService
	{
		public AddressManager(IRepository<Address, libAPIContext,int> repository) : base(repository)
		{
		}

		public override Address MapToEntity(AddressDTO dto)
		{
			return new Address
			{
				Id = dto.Id,
				AddressCountryId = dto.AddressCountryId,
				AddressCityId = dto.AddressCityId,
				ClearAddress = dto.ClearAddress
			};
		}

		public override AddressDTO MapToDto(Address entity)
		{
			return new AddressDTO
			{
				Id = entity.Id,
				AddressCountryId = entity.AddressCountryId,
				AddressCityId = entity.AddressCityId,
				ClearAddress = entity.ClearAddress
			};
		}
	}
}
