using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class LanguageManager : GenericManager<Language, LanguageCreateDTO, LanguageReadDTO, libAPIContext, string>, ILanguageService
	{
		public LanguageManager(IRepository<Language, libAPIContext, string> repository) : base(repository)
		{
		}

		public override Language MapToEntity(LanguageCreateDTO dto)
		{
			return new Language
			{
				Code = dto.Code,
				Name = dto.Name
			};
		}

		public override LanguageReadDTO MapToDto(Language entity)
		{
			return new LanguageReadDTO
			{
				Code = entity.Code,
				Name = entity.Name
			};
		}
	}
}
