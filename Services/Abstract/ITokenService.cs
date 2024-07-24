using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface ITokenService
	{
		Task<string> GenerateToken(ApplicationUser user);
	}


}
