using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
	public class BookManager : GenericManager<Book, libAPIContext, int>, IBookService
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
	}
}
