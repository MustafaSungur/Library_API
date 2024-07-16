using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class LanguageManager : GenericManager<Language, LanguageDTO, libAPIContext,string>, ILanguageService
	{
		public LanguageManager(IRepository<Language, libAPIContext,string> repository) : base(repository)
		{
		}

		protected override Language MapToEntity(LanguageDTO dto)
		{
			return new Language
			{
				Code = dto.Code,
				Name = dto.Name
			};
		}

		protected override LanguageDTO MapToDto(Language entity)
		{
			return new LanguageDTO
			{
				Code = entity.Code,
				Name = entity.Name
			};
		}

	}
}

