using libAPI.DTOs;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly IBookService _service;

		public BooksController(IBookService service)
		{
			_service = service;
		}

		// GET: api/Books
		[HttpGet]
		public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Books/5
		[HttpGet("{id}")]
		public async Task<ActionResult<BookDTO>> GetBook(int id)
		{
			var book = await _service.GetByIdAsync(id);

			if (book == null)
			{
				return NotFound();
			}

			return Ok(book);
		}

		// PUT: api/Books/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutBook(int id, BookDTO bookDto)
		{
			if (id != bookDto.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(bookDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await BookExists(id))
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

		// POST: api/Books
		[HttpPost]
		public async Task<ActionResult<BookDTO>> PostBook(BookDTO bookDto)
		{
			var createdEntity = await _service.AddAsync(bookDto);
			return CreatedAtAction("GetBook", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Books/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBook(int id)
		{
			var book = await _service.GetByIdAsync(id);
			if (book == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> BookExists(int id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
