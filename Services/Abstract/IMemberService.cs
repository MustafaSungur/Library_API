using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IMemberService:IService<Member, MemberDTO, libAPIContext,string>
	{
	}
}
