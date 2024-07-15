using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class GenreManager : GenericManager<Genre, libAPIContext,int>, IGenreService
	{
		public GenreManager(IRepository<Genre, libAPIContext,int> repository) : base(repository)
		{
		}
	}
}
