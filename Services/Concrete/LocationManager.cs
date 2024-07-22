using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class LocationManager : GenericManager<Location, LocationCreateDTO, LocationReadDTO, libAPIContext, int>, ILocationService
	{
		public LocationManager(IRepository<Location, libAPIContext, int> repository) : base(repository)
		{
		}

		public override Location MapToEntity(LocationCreateDTO dto)
		{
			return new Location
			{
				Shelf = dto.Shelf
			};
		}

		public override LocationReadDTO MapToDto(Location entity)
		{
			return new LocationReadDTO
			{
				Id = entity.Id,
				Shelf = entity.Shelf
			};
		}
	}
}
