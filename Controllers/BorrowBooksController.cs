using libAPI.DTOs;
using libAPI.Services.Abstract;
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
		public async Task<ActionResult<IEnumerable<BorrowBooksDTO>>> GetBorrowBooks()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/BorrowBooks/5
		[HttpGet("{id}")]
		public async Task<ActionResult<BorrowBooksDTO>> GetBorrowBooks(int id)
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
		public async Task<IActionResult> PutBorrowBooks(int id, BorrowBooksDTO borrowBooksDto)
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

		// POST: api/BorrowBooks
		[HttpPost]
		public async Task<ActionResult<BorrowBooksDTO>> PostBorrowBooks(BorrowBooksDTO borrowBooksDto)
		{
			var createdEntity = await _service.AddAsync(borrowBooksDto);
			return CreatedAtAction("GetBorrowBooks", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/BorrowBooks/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBorrowBooks(int id)
		{
			var borrowBooks = await _service.GetByIdAsync(id);
			if (borrowBooks == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);

			return NoContent();
		}

		private async Task<bool> BorrowBooksExists(int id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
