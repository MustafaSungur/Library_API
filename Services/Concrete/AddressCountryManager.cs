using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AddressCountryManager : GenericManager<AddressCountry, AddressCountryCreateDTO, AddressCountryReadDTO, libAPIContext, short>, IAddressCountryService
	{
		public AddressCountryManager(IRepository<AddressCountry, libAPIContext, short> repository) : base(repository)
		{
		}

		public override AddressCountry MapToEntity(AddressCountryCreateDTO dto)
		{
			return new AddressCountry
			{
				Name = dto.Name
			};
		}

		public override AddressCountryReadDTO MapToDto(AddressCountry entity)
		{
			return new AddressCountryReadDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}
	}
}
