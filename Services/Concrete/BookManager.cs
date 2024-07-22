using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
	public class BookManager : GenericManager<Book, BookCreateDTO, BookReadDTO, libAPIContext, int>, IBookService
	{
		private readonly IStockRepository _stockRepository;
		private readonly IAuthorBookService _authorBookService;
		private readonly ILanguageBookService _languageService;
		private readonly ISubcategoryBookService _subCategoryBookService;

		public BookManager(IBookRepository repository, IStockRepository stockRepository, IAuthorBookService authorBookService, ILanguageBookService languageService, ISubcategoryBookService subCategoryBookService) : base(repository)
		{
			_stockRepository = stockRepository;
			_authorBookService = authorBookService;
			_languageService = languageService;
			_subCategoryBookService = subCategoryBookService;
		}

		public override async Task<BookReadDTO> AddAsync(BookCreateDTO bookDto)
		{

			Stock stock = new Stock
			{
				ISBM = bookDto.ISBM,
				TotalCopies = bookDto.CopyCount,
				AvailableCopies = bookDto.CopyCount,
			};


			var createdStock = await _stockRepository.AddAsync(stock);

			int tempBookId =new();

			for (var copy = 0; copy < bookDto.CopyCount; copy++)
			{
				var book = MapToEntity(bookDto); 
				book.RegisterDate = DateTime.Now;
				book.StockId = createdStock.ISBM;

				var createdBook = await _repository.AddAsync(book);
				tempBookId = createdBook.Id;

				foreach (var authorId in bookDto.AuthorsIds)
				{
					await _authorBookService.AddAsync(new AuthorBookCreateDTO { AuthorId = authorId, BookId = createdBook.Id });
				}
				foreach (var languageId in bookDto.LanguageIds)
				{
					await _languageService.AddAsync(new LanguageBookCreateDTO { LanguageId = languageId, BookId = createdBook.Id });
				}
				foreach (var subCategoryId in bookDto.SubCategoryIds)
				{
					await _subCategoryBookService.AddAsync(new SubCategoryBookCreateDTO { SubCategoryId = subCategoryId, BookId = createdBook.Id });
				}
			}



			var getNewBook = await _repository.GetByIdAsync(tempBookId); 
			return MapToDto(getNewBook);
		}

		public override Book MapToEntity(BookCreateDTO dto)
		{
			var book = new Book
			{
				Title = dto.Title,
				ISBM = dto.ISBM,
				PageCount = dto.PageCount,
				PublishingYear = dto.PublishingYear,
				Description = dto.Description,
				PrintCount = dto.PrintCount,
				PublisherId = dto.PublisherId,
				LocationId = dto.LocationId,
				PhotoUrl = dto.PhotoUrl,
				CopyCount = dto.CopyCount,
			};

			return book;
		}

		public override BookReadDTO MapToDto(Book entity)
		{
			var dto = new BookReadDTO
			{
				Id = entity.Id,
				Title = entity.Title,
				ISBM = entity.ISBM,
				PageCount = entity.PageCount,
				PublishingYear = entity.PublishingYear,
				Description = entity.Description,
				PrintCount = entity.PrintCount,
				PublisherId = entity.PublisherId,
				LocationId = entity.LocationId,
				PhotoUrl = entity.PhotoUrl,
				Stock = entity.Stock,
				Authors = entity.AuthorBooks.Select(ab => new AuthorReadDTO { Id = ab.AuthorId, FullName = ab.Author.FullName }).ToList(),
				Languages = entity.LanguageBooks.Select(lb => new LanguageReadDTO { Code = lb.LanguageId, Name = lb.Language.Name }).ToList(),
				SubCategories = entity.SubCategoryBooks.Select(scb => new SubCategoryReadDTO { Id = scb.SubCategoryId, Name = scb.SubCategory.Name, Category = new CategoryReadDTO {Id=scb.SubCategory.Category.Id, Name = scb.SubCategory.Category.Name } }).ToList()
				
			};

			return dto;
		}

		}
	}

