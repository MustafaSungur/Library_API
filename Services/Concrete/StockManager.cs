using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class StockManager : GenericManager<Stock,StockDTO, libAPIContext, int>, IStockService
	{
		public StockManager(IRepository<Stock, libAPIContext, int> repository) : base(repository)
		{
		}

		public async Task<Stock> GetStockByBookIdAsync(int id)
		{
			var stock = await ((IStockRepository)_repository).GetStockByBookIdAsync(id);

			if(stock != null)
			{
				throw new Exception("Stock not found");
			}
			return stock!;
		}

		public override Stock MapToEntity(StockDTO dto)
		{
			return new Stock
			{
				Id = dto.Id,
				BookId = dto.BookId,
				Book = new Book { Id = dto.BookId }, 
				TotalCopies = dto.TotalCopies,
				AvailableCopies = dto.AvailableCopies
			};
		}

		public override StockDTO MapToDto(Stock entity)
		{
			return new StockDTO
			{
				Id = entity.Id,
				BookId = entity.BookId,
				TotalCopies = entity.TotalCopies,
				AvailableCopies = entity.AvailableCopies
			};
		}



	}
}
