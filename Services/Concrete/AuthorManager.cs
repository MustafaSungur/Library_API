using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AuthorManager : GenericManager<Author, AuthorCreateDTO, AuthorReadDTO, libAPIContext, long>, IAuthorService
	{
		public AuthorManager(IRepository<Author, libAPIContext, long> repository) : base(repository)
		{
		}

		public override Author MapToEntity(AuthorCreateDTO dto)
		{
			return new Author
			{
				FullName = dto.FullName,
				Biography = dto.Biography,
				BirthDate = dto.BirthDate,
				DeadYear = dto.DeadYear,
			};
		}

		public override AuthorReadDTO MapToDto(Author entity)
		{
			return new AuthorReadDTO
			{
				Id = entity.Id,
				FullName = entity.FullName,
				Biography = entity.Biography,
				BirthDate = entity.BirthDate,
				DeadYear = entity.DeadYear,
			};
		}
	}
}
