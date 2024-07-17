using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class LocationManager : GenericManager<Location, LocationDTO, libAPIContext,int>, ILocationService
	{
		public LocationManager(IRepository<Location, libAPIContext,int> repository) : base(repository)
		{
		}

		public override Location MapToEntity(LocationDTO dto)
		{
			return new Location
			{
				Id = dto.Id,
				Shelf = dto.Shelf
			};
		}

		public override LocationDTO MapToDto(Location entity)
		{
			return new LocationDTO
			{
				Id = entity.Id,
				Shelf = entity.Shelf
			};
		}

	}
}
