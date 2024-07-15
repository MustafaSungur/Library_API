using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreMemberRepository : EfCoreGenericRepository<Member, libAPIContext,string>,IMemberRepository
	{
		public EfCoreMemberRepository(libAPIContext context) : base(context)
		{
		}
	}
}
