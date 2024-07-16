
using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AuthorManager : GenericManager<Author, AuthorDTO, libAPIContext,int>, IAuthorService
	{
		public AuthorManager(IRepository<Author, libAPIContext,int> repository) : base(repository)
		{
		}

		protected override Author MapToEntity(AuthorDTO dto)
		{
			return new Author
			{
				Id = dto.Id,
				FullName = dto.FullName,
				Biography = dto.Biography,
				BirthDate = dto.BirthDate,
				DeadYear = dto.DeadYear,
			};
		}

		protected override AuthorDTO MapToDto(Author entity)
		{
			return new AuthorDTO
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
