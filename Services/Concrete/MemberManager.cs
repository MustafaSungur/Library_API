using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class MemberManager : GenericManager<Member, libAPIContext,string>, IMemberService
	{
		public MemberManager(IRepository<Member, libAPIContext,string> repository) : base(repository)
		{
		}
	}
}
