using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AddressCountryManager : GenericManager<AddressCountry, AddressCountryDTO, libAPIContext,int>, IAddressCountryService
	{
		public AddressCountryManager(IRepository<AddressCountry, libAPIContext,int> repository) : base(repository)
		{
		}

		protected override AddressCountry MapToEntity(AddressCountryDTO dto)
		{
			return new AddressCountry
			{
				Id = dto.Id,
				Name = dto.Name
			};
		}

		protected override AddressCountryDTO MapToDto(AddressCountry entity)
		{
			return new AddressCountryDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}


	}
}
