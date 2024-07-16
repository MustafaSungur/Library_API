
using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IPublisherService:IService<Publisher, PublisherDTO, libAPIContext,int>
	{
	}
}
