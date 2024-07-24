using libAPI.Models;
using libAPI.Services.Abstract;
using libAPI.Services.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace libAPI.Controllers.Auth
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ITokenService _tokenService;

		public AuthController(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
			_userManager = userManager;
			_tokenService = tokenService;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(string userName, string password)
		{
			ApplicationUser applicationUser = await _userManager.FindByNameAsync(userName);

			if (applicationUser != null && await _userManager.CheckPasswordAsync(applicationUser, password))
			{
				var token = await _tokenService.GenerateToken(applicationUser);
				return Ok(new { token });
			}
			return Unauthorized();
		}



	


	}
}
