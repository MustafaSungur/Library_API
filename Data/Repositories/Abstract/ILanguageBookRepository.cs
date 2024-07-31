using libAPI.Models;

namespace libAPI.Data.Repositories.Abstract
{
	public interface ILanguageBookRepository : IRepository<LanguageBook, libAPIContext, int>
	{
		Task<List<LanguageBook>> FindByBookIdAsync(int bookId);
		Task RemoveAsync(LanguageBook languageBook);
	}
}
