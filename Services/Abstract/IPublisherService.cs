
using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IPublisherService:IService<Publisher, PublisherCreateDTO, PublisherReadDTO, libAPIContext,int>
	{
	}
}
