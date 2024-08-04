using libAPI.Models;
using libAPI.Services.Abstract;

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
		private readonly IConfiguration _configuration;

		public AuthController(UserManager<ApplicationUser> userManager, ITokenService tokenService, IConfiguration configuration)
        {
			_userManager = userManager;
			_tokenService = tokenService;
			_configuration = configuration;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(string email, string password)
		{
			ApplicationUser applicationUser = await _userManager.FindByEmailAsync(email);

			if (applicationUser != null && await _userManager.CheckPasswordAsync(applicationUser, password))
			{
				var token = await _tokenService.GenerateToken(applicationUser);
				return Ok(new { token, exprition = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"]))});
			}
			return Unauthorized();
		}


		[HttpPost("ForgetPassword")]
		public async Task<ActionResult<string>> ForgetPassword(string email)
		{
			var applicationUser = await _userManager.FindByEmailAsync(email);
			if (applicationUser == null)
			{
				return NotFound("User not found.");
			}

				
			if (applicationUser.UserName == "Admin")
			{
				throw new Exception("Access Danied");
			}

			var token = await _userManager.GeneratePasswordResetTokenAsync(applicationUser);
			try
			{
			    EmailManager.SendEmail(applicationUser.Email, "Şifre Sıfırlama", token);
				return Ok(token);
			}
			catch (Exception ex)
			{
				// Log the exception details here for debugging
				return StatusCode(StatusCodes.Status500InternalServerError, "Error sending email.");
			}
		}



		[HttpPost("ResetPassword")]
		public async Task<IActionResult> ResetPassword(string email, string token, string newPassword)
		{
			var applicationUser = await _userManager.FindByEmailAsync(email);
			if (applicationUser == null)
			{
				return NotFound("User not found");
			}

	
			if (applicationUser.UserName == "Admin")
			{
				throw new Exception("Access Danied");
			}

			var result = await _userManager.ResetPasswordAsync(applicationUser, token, newPassword);
			if (result.Succeeded)
			{
				return Ok();
			}

			return BadRequest(result.Errors);
		}






	}
}
