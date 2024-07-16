using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class PublisherManager : GenericManager<Publisher, PublisherDTO, libAPIContext,int>, IPublisherService
	{
		public PublisherManager(IRepository<Publisher, libAPIContext,int> repository) : base(repository)
		{


			protected override Publisher MapToEntity(PublisherDTO dto)
		{
			return new Publisher
			{
				Id = dto.Id,
				Name = dto.Name,
				Phone = dto.Phone,
				Email = dto.Email,
				ContactPerson = dto.ContactPerson
			};
		}

		protected override PublisherDTO MapToDto(Publisher entity)
		{
			return new PublisherDTO
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
