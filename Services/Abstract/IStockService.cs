using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IStockService:IService<Stock, StockCreateDTO, StockReadDTO, libAPIContext,string>
	{
	
	}
	
}
