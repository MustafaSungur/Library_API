using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Identity;


namespace libAPI.Services.Concrete
{
	public class BookManager : GenericManager<Book, BookCreateDTO, BookReadDTO, libAPIContext, int>, IBookService
	{
		private readonly IStockRepository _stockRepository;
		private readonly IBorrowHistoryRepository _borrowHistoryRepository;
		private readonly IAuthorBookRepository _authorBookRepository;
		private readonly ILanguageBookRepository _languageBookRepository;
		private readonly ISubCategoryBookRepository _subCategoryBookRepository;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IBookRepository _bookRepository;
	

		public BookManager(
			IBookRepository repository,
			IStockRepository stockRepository,
			IAuthorBookRepository authorBookRepository,
			ILanguageBookRepository languageBookRepository,
			ISubCategoryBookRepository subCategoryBookRepository,
			UserManager<ApplicationUser> userManager,
			IBookRepository bookRepository,
		IBorrowHistoryRepository borrowHistoryRepository) : base(repository)
		{
			_bookRepository = bookRepository;
			_stockRepository = stockRepository;
			_authorBookRepository = authorBookRepository;
			_languageBookRepository = languageBookRepository;
			_subCategoryBookRepository = subCategoryBookRepository;
			_userManager = userManager;
			_borrowHistoryRepository = borrowHistoryRepository;
		}


		public override async Task<BookReadDTO> AddAsync(BookCreateDTO bookDto)
		{

			Stock stock = new Stock
			{
				ISBM = bookDto.ISBM!,
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
				book.RatingCount = 0;
				book.TotalRating = 0;

				var createdBook = await _repository.AddAsync(book);
				tempBookId = createdBook.Id;

				foreach (var authorId in bookDto.AuthorsIds!)
				{
					await _authorBookRepository.AddAsync(new AuthorBook { AuthorId = authorId, BookId = createdBook.Id });
				}
				foreach (var languageId in bookDto.LanguageIds!)
				{
					await _languageBookRepository.AddAsync(new LanguageBook { LanguageId = languageId, BookId = createdBook.Id });
				}
				foreach (var subCategoryId in bookDto.SubCategoryIds!)
				{
					await _subCategoryBookRepository.AddAsync(new SubCategoryBook { SubCategoryId = subCategoryId, BookId = createdBook.Id });
				}
			}



			var getNewBook = await _repository.GetByIdAsync(tempBookId); 
			return MapToDto(getNewBook!);
		}

		public async Task UpdateBookAsync(int bookId, BookCreateDTO bookDTO)
		{
			var book = await _repository.GetByIdAsync(bookId);
			if (book == null || book.Status==false)
			{
				throw new Exception("Book not found");
			}

			// Update basic properties
			book.Title = bookDTO.Title;
			book.ISBM = bookDTO.ISBM;
			book.PageCount = bookDTO.PageCount;
			book.PublishingYear = bookDTO.PublishingYear;
			book.Description = bookDTO.Description;
			book.PrintCount = bookDTO.PrintCount;
			book.PublisherId = bookDTO.PublisherId;
			book.LocationId = bookDTO.LocationId;
			book.PhotoUrl = bookDTO.PhotoUrl;

			
		

			// Update relational properties
			await UpdateLanguageBooksAsync(book.Id, bookDTO.LanguageIds!);
			await UpdateSubCategoryBooksAsync(book.Id, bookDTO.SubCategoryIds!);
			await UpdateAuthorBooksAsync(book.Id, bookDTO.AuthorsIds!);

			await _repository.UpdateAsync(book);
		}

		private async Task UpdateAuthorBooksAsync(int bookId, List<short> newAuthorIds)
		{
			var existingAuthors = await _authorBookRepository.FindByBookIdAsync(bookId);
			var toRemove = existingAuthors.Where(x => !newAuthorIds.Contains((short)x.AuthorId)).ToList();
			var toAdd = newAuthorIds.Where(id => !existingAuthors.Any(x => x.AuthorId == id)).Select(id => new AuthorBook { AuthorId = id, BookId = bookId }).ToList();

			foreach (var authorBook in toRemove)
			{
				await _authorBookRepository.RemoveAsync(authorBook);
			}

			foreach (var authorBook in toAdd)
			{
				await _authorBookRepository.AddAsync(authorBook);
			}
		}

		private async Task UpdateLanguageBooksAsync(int bookId, List<string> newLanguageIds)
		{
			var existingLanguages = await _languageBookRepository.FindByBookIdAsync(bookId);
			var toRemove = existingLanguages.Where(x => !newLanguageIds.Contains(x.LanguageId)).ToList();
			var toAdd = newLanguageIds.Where(id => !existingLanguages.Any(x => x.LanguageId == id)).Select(id => new LanguageBook { LanguageId = id, BookId = bookId }).ToList();

			foreach (var languageBook in toRemove)
			{
				await _languageBookRepository.RemoveAsync(languageBook);
			}

			foreach (var languageBook in toAdd)
			{
				await _languageBookRepository.AddAsync(languageBook);
			}
		}

		private async Task UpdateSubCategoryBooksAsync(int bookId, List<short> newSubCategoryIds)
		{
			var existingSubCategories = await _subCategoryBookRepository.FindByBookIdAsync(bookId);
			var toRemove = existingSubCategories.Where(x => !newSubCategoryIds.Contains(x.SubCategoryId)).ToList();
			var toAdd = newSubCategoryIds.Where(id => !existingSubCategories.Any(x => x.SubCategoryId == id)).Select(id => new SubCategoryBook { SubCategoryId = id, BookId = bookId }).ToList();

			foreach (var subCategoryBook in toRemove)
			{
				await _subCategoryBookRepository.RemoveAsync(subCategoryBook);
			}

			foreach (var subCategoryBook in toAdd)
			{
				await _subCategoryBookRepository.AddAsync(subCategoryBook);
			}
		}
		public async Task<Stock> UpdateStockAsync(string ISBM, int totalCopies, List<int>? bookIdsToRemove = null)
		{
			var stock = await _stockRepository.GetByIdAsync(ISBM) ?? throw new Exception("Stock not found");

			int borrowedCopies = stock.TotalCopies - stock.AvailableCopies;
			stock.TotalCopies = totalCopies;
			stock.AvailableCopies = totalCopies - borrowedCopies;

			var books = await _bookRepository.GetByIsbmAsync(ISBM) ?? throw new Exception("Books not found");
			int currentBookCount = books.Count();

			if (totalCopies > currentBookCount)
			{
				var firstBook = books.FirstOrDefault() ?? throw new Exception("No book found to copy details from");

				// Fetch related data from the database
				var authors = await _authorBookRepository.FindByBookIdAsync(firstBook.Id);
				var languages = await _languageBookRepository.FindByBookIdAsync(firstBook.Id);
				var subCategories = await _subCategoryBookRepository.FindByBookIdAsync(firstBook.Id);

				for (var copy = currentBookCount; copy < totalCopies; copy++)
				{
					var book = new Book
					{
						ISBM = ISBM,
						StockId = ISBM,
						RegisterDate = DateTime.Now,
						RatingCount = 0,
						TotalRating = 0,
						Title = firstBook.Title,
						PageCount = firstBook.PageCount,
						PublishingYear = firstBook.PublishingYear,
						Description = firstBook.Description,
						PrintCount = firstBook.PrintCount,
						PublisherId = firstBook.PublisherId,
						LocationId = firstBook.LocationId,
						PhotoUrl = firstBook.PhotoUrl
					};
					var createdBook = await _bookRepository.AddAsync(book);

					foreach (var author in authors)
					{
						await _authorBookRepository.AddAsync(new AuthorBook { AuthorId = author.AuthorId, BookId = createdBook.Id });
					}
					foreach (var language in languages)
					{
						await _languageBookRepository.AddAsync(new LanguageBook { LanguageId = language.LanguageId, BookId = createdBook.Id });
					}
					foreach (var subCategory in subCategories)
					{
						await _subCategoryBookRepository.AddAsync(new SubCategoryBook { SubCategoryId = subCategory.SubCategoryId, BookId = createdBook.Id });
					}
				}
			}
			else if (totalCopies < currentBookCount)
			{
				List<int> booksToRemoveIds;

				if (bookIdsToRemove != null && bookIdsToRemove.Count > 0)
				{
					booksToRemoveIds = bookIdsToRemove;
				}
				else
				{
					booksToRemoveIds = books.OrderByDescending(b => b.RegisterDate)
											 .Take(currentBookCount - totalCopies)
											 .Select(b => b.Id)
											 .ToList();
				}

				foreach (var bookId in booksToRemoveIds)
				{
					await _bookRepository.DeleteAsync(bookId);
				}
			}

			var result = await _stockRepository.UpdateAsync(stock);

			return result;
		}




		public async Task<string> RateBook(int bookId, short rate, string userEmail)
		{
			if (rate < 0 || rate > 5) throw new Exception("Rate must be between 0 and 5");

			var user = await _userManager.FindByEmailAsync(userEmail);

			var book = await _repository.GetByIdAsync(bookId);

			if (book == null || book.Status==false)
			{
				throw new Exception("Book does not exist");
			}

			if (book.RatedMemberIds == null)
			{
				book.RatedMemberIds = new List<string>(); 
			}

			var isRatedMember = book.RatedMemberIds.Any(id => id == user?.Id);

			if (isRatedMember)
			{
				throw new Exception("Member has already rated this book");
			}

			var isHistoryBook = await _borrowHistoryRepository.GetByMemberAndBookAsync(user!.Id, bookId);

			if (isHistoryBook == null) throw new Exception("You have to borrow the book for rating");

			book.RatedMemberIds.Add(user?.Id!); 
			book.RatingCount += 1;
			book.TotalRating += rate;

			await _repository.UpdateAsync(book);

			return "Book rated successfully";
		}


		public override async Task<bool> DeleteAsync(int id)
		{
			var book = await _repository.GetByIdAsync(id) ?? throw new Exception("Book not found");

			book.Status = false!;

			var result = await _repository.UpdateAsync(book);

			return !result.Status;
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
				ISBM = entity.ISBM!,
				PageCount = entity.PageCount,
				PublishingYear = entity.PublishingYear,
				Description = entity.Description!,
				PrintCount = entity.PrintCount,
				PublisherId = entity.PublisherId,
				LocationId = entity.LocationId,
				PhotoUrl = entity.PhotoUrl!,
				Stock = entity.Stock,
				Status= entity.Status,
				Raiting = entity.RatingCount != 0 ? (float) (entity.TotalRating / entity.RatingCount)! : 0,
				RaitingCount = (int) entity.RatingCount!,
				Authors = entity.AuthorBooks!.Select(ab => new AuthorReadDTO { Id = ab.AuthorId, FullName = ab.Author!.FullName }).ToList(),
				Languages = entity.LanguageBooks!.Select(lb => new LanguageReadDTO { Code = lb.LanguageId, Name = lb.Language!.Name }).ToList(),
				SubCategories = entity.SubCategoryBooks!.Select(scb => new SubCategoryReadDTO { Id = scb.SubCategoryId, Name = scb.SubCategory!.Name, Category = new CategoryReadDTO {Id=scb.SubCategory.Category!.Id, Name = scb.SubCategory.Category.Name } }).ToList()
				
			};

			return dto;
		}

		}
	}

