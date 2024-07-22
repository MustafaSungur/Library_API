using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class LanguageBookManager : GenericManager<LanguageBook, LanguageBookCreateDTO, LanguageBookReadDTO, libAPIContext, int>, ILanguageBookService
	{
		public LanguageBookManager(IRepository<LanguageBook, libAPIContext, int> repository) : base(repository)
		{
		}

		public override LanguageBook MapToEntity(LanguageBookCreateDTO dto)
		{
			return new LanguageBook
			{
				BookId = dto.BookId,
				LanguageId = dto.LanguageId
			};
		}

		public override LanguageBookReadDTO MapToDto(LanguageBook entity)
		{
			return new LanguageBookReadDTO
			{
				BookId = entity.BookId,
				LanguageId = entity.LanguageId,
	
			};
		}
	}
}
