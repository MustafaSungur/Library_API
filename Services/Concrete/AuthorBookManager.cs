using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class AuthorBookManager : GenericManager<AuthorBook, AuthorBookCreateDTO, AuthorBookReadDTO, libAPIContext, int>, IAuthorBookService
	{
		public AuthorBookManager(IRepository<AuthorBook, libAPIContext, int> repository) : base(repository)
		{
		}

		public override AuthorBook MapToEntity(AuthorBookCreateDTO dto)
		{
			return new AuthorBook
			{
				AuthorId = dto.AuthorId,
				BookId = dto.BookId
			};
		}

		public override AuthorBookReadDTO MapToDto(AuthorBook entity)
		{
			return new AuthorBookReadDTO
			{
				AuthorId = entity.AuthorId,
				BookId = entity.BookId,
				
				
			};
		}
	}
}
