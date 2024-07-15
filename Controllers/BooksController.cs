using libAPI.Models;
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
		public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Books/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Book>> GetBook(int id)
		{
			var book = await _service.GetByIdAsync(id);

			if (book == null)
			{
				return NotFound();
			}

			return book;
		}

		// PUT: api/Books/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutBook(int id, Book book)
		{
			if (id != book.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(book);
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
		public async Task<ActionResult<Book>> PostBook(Book book)
		{
			var createdEntity = await _service.AddAsync(book);
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
