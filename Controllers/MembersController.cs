using System.Security.Claims;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MembersController : ControllerBase
	{
		private readonly IMemberService _service;
		private readonly IBorrowHistoryService _borrowHistoryService;
		private readonly UserManager<ApplicationUser> _userManager;
		public MembersController(IMemberService service, IBorrowHistoryService borrowHistoryService, UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
			_service = service;
			_borrowHistoryService = borrowHistoryService;
		}

		// GET: api/Members
		[HttpGet]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<IEnumerable<MemberReadDTO>>> GetMembers()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Members/History/{memberId}
		[HttpGet("History/{memberId}")]
		[Authorize(Roles = "Admin,Worker,Member")]
		public async Task<ActionResult<IEnumerable<BorrowHistoryReadDTO>>> GetMemberBookHistory(string memberId)
		{

			var email = User.FindFirstValue(ClaimTypes.Email);
			var user = await _userManager.FindByEmailAsync(email);
			

			if (user!.Id == null)
			{
				return StatusCode(403, "Authentication failed: User ID is null.");
			}

			bool isMember = await _userManager.IsInRoleAsync(user, "Member");					

			if (isMember && user.Id != memberId)
			{
				return StatusCode(403, "Access denied.");
			}


			var result = await _borrowHistoryService.GetAllByMemberIdAsync(memberId);
			if (result == null || result.Count == 0) 
			{
				return NotFound($"No borrowing history found for member with ID: {memberId}");
			}

			return Ok(result);
		}

		// GET: api/Members/5
		[HttpGet("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<MemberReadDTO>> GetMember(string id)
		{
			var member = await _service.GetByIdAsync(id);

			if (member == null)
			{
				return NotFound();
			}

			return Ok(member);
		}

		// PUT: api/Members/5
		[HttpPut("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> PutMember(string id, MemberCreateDTO member)
		{
			if (id != member.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(member);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await MemberExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Members
		[HttpPost]
		public async Task<ActionResult<MemberReadDTO>> PostMember(MemberCreateDTO member)
		{
			try
			{
				var createdEntity = await _service.AddAsync(member);
				return CreatedAtAction("GetMember", new { id = createdEntity.Id }, createdEntity);
			}
			catch (DbUpdateException)
			{
				if (await MemberExists(member.Id))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}
		}

		// DELETE: api/Members/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> DeleteMember(string id)
		{
			var member = await _service.GetByIdAsync(id);
			if (member == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}


		// BAN: api/Members/Ban/5
		[HttpPost("Ban/{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> BanMember(string id)
		{
			var result = await _service.BanMember(id);
			return Ok(result);
		}

		// REMOVE BAN: api/Members/RemoveBan/5
		[HttpPost("RemoveBan/{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> RemoveBanMember(string id)
		{
			var result = await _service.RemoveBanMember(id);
			return Ok(result);
		}

		private async Task<bool> MemberExists(string id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
