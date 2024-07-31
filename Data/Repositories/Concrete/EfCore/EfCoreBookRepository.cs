using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreBookRepository : EfCoreGenericRepository<Book, libAPIContext, int>, IBookRepository
	{
		public EfCoreBookRepository(libAPIContext context) : base(context)
		{
		}

		public override async Task<Book> AddAsync(Book entity)
		{
			await _context.Book.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public override async Task<bool> DeleteAsync(int id)
		{
			var entity = await _context.Book
				.Include(b => b.AuthorBooks)
				.Include(b => b.LanguageBooks)
				.Include(b => b.SubCategoryBooks)
				.FirstOrDefaultAsync(b => b.Id == id);

			if (entity == null)
			{
				return false;
			}

			_context.Book.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}

		public override async Task<IEnumerable<Book>> GetAllAsync()
		{
			return await _context.Book
				.AsTracking()
				.Include(b => b.AuthorBooks).ThenInclude(ab => ab.Author)
				.Include(b => b.LanguageBooks).ThenInclude(lb => lb.Language)
				.Include(b => b.Stock)
				.Include(b => b.SubCategoryBooks).ThenInclude(sb => sb.SubCategory).ThenInclude(sbb => sbb.Category)
				
				.ToListAsync();
		}

		public override async Task<Book> GetByIdAsync(int id)
		{
			return await _context.Book
				.AsTracking()
				.Include(b => b.AuthorBooks).ThenInclude(ab => ab.Author)
				.Include(b => b.LanguageBooks).ThenInclude(lb => lb.Language)
				.Include(b => b.Stock)
				.Include(b => b.SubCategoryBooks).ThenInclude(sb => sb.SubCategory).ThenInclude(sbb => sbb.Category)
	
				.FirstOrDefaultAsync(b => b.Id == id);
		}

		public async Task<IEnumerable<Book>> GetByIsbmAsync(string ISBM)
		{
			return await _context.Book
				.AsTracking()
				.Include(b => b.AuthorBooks)
				.Include(b => b.LanguageBooks)
				.Include(b => b.SubCategoryBooks)
				.Where(b => b.ISBM == ISBM)
				.ToListAsync();
		}


		public override async Task<Book> UpdateAsync(Book entity)
		{
			var existingBook = await _context.Book
				.Include(b => b.AuthorBooks)
				.Include(b => b.LanguageBooks)
				.Include(b => b.SubCategoryBooks)
				.FirstOrDefaultAsync(b => b.Id == entity.Id);

			if (existingBook == null)
			{
				return null;
			}

			// Update scalar properties
			existingBook.Title = entity.Title;
			existingBook.ISBM = entity.ISBM;
			existingBook.PageCount = entity.PageCount;
			existingBook.PublishingYear = entity.PublishingYear;
			existingBook.Description = entity.Description;
			existingBook.PrintCount = entity.PrintCount;
			existingBook.PublisherId = entity.PublisherId;
			existingBook.LocationId = entity.LocationId;
			existingBook.PhotoUrl = entity.PhotoUrl;
			existingBook.StockId = entity.StockId;
			// Update relationships
			existingBook.AuthorBooks = entity.AuthorBooks;
			existingBook.LanguageBooks = entity.LanguageBooks;
			existingBook.SubCategoryBooks = entity.SubCategoryBooks;

			_context.Book.Update(existingBook);
			await _context.SaveChangesAsync();
			return existingBook;
		}
	}
}
