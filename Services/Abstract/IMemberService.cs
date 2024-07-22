using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IMemberService : IService<Member, MemberCreateDTO, MemberReadDTO, libAPIContext, string>
	{
	
	}
}
