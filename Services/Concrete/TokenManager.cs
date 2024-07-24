using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenManager : ITokenService
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly IConfiguration _configuration;

	public TokenManager(UserManager<ApplicationUser> userManager, IConfiguration configuration)
	{
		_userManager = userManager;
		_configuration = configuration;
	}

	public async Task<string> GenerateToken(ApplicationUser user)
	{
		var userClaims = await _userManager.GetClaimsAsync(user);
		var roles = await _userManager.GetRolesAsync(user);
		var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

		var claims = new List<Claim>
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new Claim(JwtRegisteredClaimNames.NameId, user.Id)
		};

		if (!string.IsNullOrEmpty(user.Email))
		{
			claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
		}

		claims.AddRange(userClaims);
		claims.AddRange(roleClaims);

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
		var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"]));

		var token = new JwtSecurityToken(
			issuer: _configuration["Jwt:Issuer"],
			audience: _configuration["Jwt:Audience"],
			claims: claims,
			expires: expiration,
			signingCredentials: creds);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
