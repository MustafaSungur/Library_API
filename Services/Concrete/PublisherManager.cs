using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class PublisherManager : GenericManager<Publisher, PublisherCreateDTO, PublisherReadDTO, libAPIContext, int>, IPublisherService
	{
		public PublisherManager(IRepository<Publisher, libAPIContext, int> repository) : base(repository)
		{
		}

		public override Publisher MapToEntity(PublisherCreateDTO dto)
		{
			return new Publisher
			{
				Name = dto.Name,
				Phone = dto.Phone,
				Email = dto.Email,
				ContactPerson = dto.ContactPerson
			};
		}

		public override PublisherReadDTO MapToDto(Publisher entity)
		{
			return new PublisherReadDTO
			{
				Id = entity.Id,
				Name = entity.Name,
				Phone = entity.Phone,
				Email = entity.Email,
				ContactPerson = entity.ContactPerson
			};
		}
	}
}
