using System.Security.Claims;
using libAPI.DTOs;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BorrowBooksController : ControllerBase
	{
		private readonly IBorrowBooksService _service;

		public BorrowBooksController(IBorrowBooksService service)
		{
			_service = service;
		}

		// GET: api/BorrowBooks
		[HttpGet]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<IEnumerable<BorrowBooksReadDTO>>> GetBorrowBooks()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/BorrowBooks/5
		[HttpGet("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<BorrowBooksReadDTO>> GetBorrowBooks(int id)
		{
			var borrowBooks = await _service.GetByIdAsync(id);

			if (borrowBooks == null)
			{
				return NotFound();
			}

			return Ok(borrowBooks);
		}

		// PUT: api/BorrowBooks/5
		[HttpPut("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> PutBorrowBooks(int id, BorrowBooksCreateDTO borrowBooksDto)
		{
			if (id != borrowBooksDto.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(borrowBooksDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await BorrowBooksExists(id))
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

		[HttpPost]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<IEnumerable<BorrowBooksReadDTO>>> PostBorrowBooks(BorrowBooksCreateDTO borrowBooksDto)
		{
			var employeeEmail = User.FindFirstValue(ClaimTypes.Email);

		
			var createdEntities = await _service.AddListAsync(borrowBooksDto, employeeEmail);

			return CreatedAtAction(nameof(GetBorrowBooks), new { createdEntities });
		}




		// DELETE: api/BorrowBooks/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> DeleteBorrowBooks(int id)
		{
	
			var borrowBooks = await _service.GetByIdAsync(id);

			if (borrowBooks == null)
			{
				return NotFound();
			}

			var employeeEmail = User.FindFirstValue(ClaimTypes.Email);

			await _service.DeleteBorrowBookAsync(id,employeeEmail);

			return NoContent();
		}

		private async Task<bool> BorrowBooksExists(int id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
