using libAPI.DTOs;
using libAPI.Services.Abstract;
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
		public MembersController(IMemberService service, IBorrowHistoryService borrowHistoryService)
		{
			_service = service;
			_borrowHistoryService = borrowHistoryService;
		}

		// GET: api/Members
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MemberReadDTO>>> GetMembers()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Members/History/{memberId}
		[HttpGet("History/{memberId}")]
		public async Task<ActionResult<IEnumerable<BorrowHistoryReadDTO>>> GetMemberBookHistory(string memberId)
		{
			var result = await _borrowHistoryService.GetAllByMemberIdAsync(memberId);
			if (result == null || !result.Any()) // If no results, return NotFound
			{
				return NotFound($"No borrowing history found for member with ID: {memberId}");
			}

			return Ok(result);
		}

		// GET: api/Members/5
		[HttpGet("{id}")]
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

		private async Task<bool> MemberExists(string id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
