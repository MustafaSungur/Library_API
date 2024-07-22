using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AddressManager : GenericManager<Address, AddressCreateDTO, AddressReadDTO, libAPIContext, int>, IAddressService
	{

		public AddressManager(IAddressRepository repository) : base(repository)
		{
 
		}



		public override Address MapToEntity(AddressCreateDTO dto)
		{
			return new Address
			{
				AddressCountryId = dto.AddressCountryId,
				AddressCityId = dto.AddressCityId,
				ClearAddress = dto.ClearAddress
			};
		}

		public override AddressReadDTO MapToDto(Address entity)
		{
			return new AddressReadDTO
			{
				Id = entity.Id,
				City = new AddressCityReadDTO { Id=entity.AddressCityId,Name=entity.City.Name},
				Country = new AddressCountryReadDTO { Id=entity.AddressCountryId, Name = entity.Country.Name}, 
				ClearAddress = entity.ClearAddress
			};
		}

		public void DetachEntity(Address address)
		{
			_repository.DetachEntity(address);
		}
	}
}
