using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
	public class BookManager : GenericManager<Book, BookDTO, libAPIContext, int>, IBookService
	{
		private readonly IStockService _stockService;

		public BookManager(IRepository<Book, libAPIContext, int> repository, IStockService stockService) : base(repository)
		{
			_stockService = stockService;
		}

		public override async Task<Book> AddAsync(Book book)
		{
			var createdBook = await _repository.AddAsync(book);

			Stock stock = new Stock
			{
				BookId = createdBook.Id,
				Book = createdBook,
				TotalCopies = book.CopyCount,
				AvailableCopies = book.CopyCount,
			};

			await _stockService.AddAsync(stock);
			return createdBook;
		}


		protected override Book MapToEntity(BookDTO dto)
		{
			return new Book
			{
				Id = dto.Id,
				AuthorsIds = dto.AuthorsIds,
				Title = dto.Title,
				ISBM = dto.ISBM,
				PageCount = dto.PageCount,
				PublishingYear = dto.PublishingYear,
				Description = dto.Description,
				PrintCount = dto.PrintCount,
				PublisherId = dto.PublisherId,
				SubCategoryBooks = dto.SubCategoryBooks?.Select(scb => new SubCategoryBook
				{
					BookId = scb.BookId,
					SubCategoryId = scb.SubCategoryId
				}).ToList(),
				LanguageBooks = dto.LanguageBooks?.Select(lb => new LanguageBook
				{
					BookId = lb.BookId,
					LanguageId = lb.LanguageId,
					Language = new Language { Code = lb.LanguageId } // Language özelliğini başlatma
				}).ToList(),
				LocationId = dto.LocationId,
				AuthorBooks = dto.AuthorBooks?.Select(ab => new AuthorBook
				{
					AuthorId = ab.AuthorId,
					BookId = ab.BookId
				}).ToList(),
				Is = dto.Is,
				PhotoUrl = dto.PhotoUrl,
				CopyCount = dto.CopyCount
			};
		}


		protected override BookDTO MapToDto(Book entity)
		{
			return new BookDTO
			{
				Id = entity.Id,
				AuthorsIds = entity.AuthorsIds,
				Title = entity.Title,
				ISBM = entity.ISBM,
				PageCount = entity.PageCount,
				PublishingYear = entity.PublishingYear,
				Description = entity.Description,
				PrintCount = entity.PrintCount,
				PublisherId = entity.PublisherId,
				SubCategoryBooks = entity.SubCategoryBooks?.Select(scb => new SubCategoryBookDTO { BookId = scb.BookId, SubCategoryId = scb.SubCategoryId }).ToList(),
				LanguageBooks = entity.LanguageBooks?.Select(lb => new LanguageBookDTO { BookId = lb.BookId, LanguageId = lb.LanguageId }).ToList(),
				LocationId = entity.LocationId,
				AuthorBooks = entity.AuthorBooks?.Select(ab => new AuthorBookDTO { AuthorId = ab.AuthorId, BookId = ab.BookId }).ToList(),
				Is = entity.Is,
				PhotoUrl = entity.PhotoUrl,
				CopyCount = entity.CopyCount
			};
		}

	}
}
