using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class PublisherManager : GenericManager<Publisher, libAPIContext>, IPublisherService
	{
		public PublisherManager(IRepository<Publisher, libAPIContext> repository) : base(repository)
		{
		}
	}
}
