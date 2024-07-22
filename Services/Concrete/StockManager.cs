using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using System;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
	public class StockManager : GenericManager<Stock, StockCreateDTO, StockReadDTO, libAPIContext, string>, IStockService
	{

		public StockManager(IRepository<Stock,libAPIContext,string> repository) : base(repository)
		{
		}

		
		public override Stock MapToEntity(StockCreateDTO dto)
		{
			return new Stock
			{
				ISBM = dto.ISBM,
				TotalCopies = dto.TotalCopies,
				AvailableCopies = dto.AvailableCopies
			};
		}

		public override StockReadDTO MapToDto(Stock entity)
		{
			var dto = new StockReadDTO
			{
				ISBM = entity.ISBM,
				TotalCopies = entity.TotalCopies,
				AvailableCopies = entity.AvailableCopies,
				
				
			};

			return dto;
		}

	}



}
