using libAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace libAPI.Data.Repositories.Abstract
{
	public interface ISubCategoryBookRepository:IRepository<SubCategoryBook, libAPIContext, int>
	{
		Task<List<SubCategoryBook>> FindByBookIdAsync(int bookId);
		Task RemoveAsync(SubCategoryBook subCategoryBook);
	

	}
}
