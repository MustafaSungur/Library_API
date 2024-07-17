using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AddressCityManager : GenericManager<Models.AddressCity, DTOs.AddressCityDTO, libAPIContext,int>, IAddressCityService
	{
		public AddressCityManager(IRepository<Models.AddressCity, libAPIContext,int> repository) : base(repository)
		{
		}

		public override Models.AddressCity MapToEntity(DTOs.AddressCityDTO dto)
		{
			return new Models.AddressCity
			{
				Id = dto.Id,
				Name = dto.Name
			};
		}

		public override DTOs.AddressCityDTO MapToDto(Models.AddressCity entity)
		{
			return new DTOs.AddressCityDTO
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}
	}
}
