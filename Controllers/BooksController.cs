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
	public class BooksController : ControllerBase
	{
		private readonly IBookService _service;
		private readonly IStockService _stockService;
		private readonly IWebHostEnvironment _environment;
		public BooksController(IBookService service, IStockService stockService, IWebHostEnvironment environment)
		{
			_stockService = stockService;
			_service = service;
			_environment = environment;

		}

		// GET: api/Books
		[HttpGet]
		public async Task<ActionResult<IEnumerable<BookReadDTO>>> GetBooks()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Books/5
		[HttpGet("{id}")]
		public async Task<ActionResult<BookReadDTO>> GetBook(int id)
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
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> UpdateBook(int id, [FromForm] BookCreateDTO bookDto, IFormFile? file=null)
		{
			// Validate the ID in the request against the ID in the DTO
			if (id != bookDto.Id)
			{
				return BadRequest("The ID in the URL does not match the ID in the provided data.");
			}

			if (file != null && file.Length > 0)
			{
				// Process the file upload
				var fileName = Path.GetFileName(file.FileName);
				var filePath = Path.Combine(_environment.WebRootPath, "uploads", fileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(fileStream);
				}

				// Update the PhotoUrl in the DTO to the new file path
				bookDto.PhotoUrl = Path.Combine("uploads", fileName);
			}

			try
			{
				// Attempt to update the book using the service layer
				await _service.UpdateAsync(bookDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				// Check if the book still exists when a concurrency issue is detected
				if (!await BookExists(id))
				{
					return NotFound($"A book with ID {id} was not found.");
				}
				else
				{
					// If the book exists, rethrow the exception to be handled by the global exception handler
					throw;
				}
			}

			// Return NoContent if the update is successful and nothing went wrong
			return NoContent();
		}


		// POST: api/Books
		[HttpPost]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<BookReadDTO>> PostBook([FromForm] BookCreateDTO bookDto, IFormFile? file=null)
		{
			if (file != null && file.Length > 0)
			{
				var fileName = Path.GetFileName(file.FileName);
				var filePath = Path.Combine(_environment.WebRootPath, "uploads", fileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(fileStream);
				}

				// Assuming your DTO has a field to accept the URL
				bookDto.PhotoUrl = Path.Combine("uploads", fileName);
			}

			var createdEntity = await _service.AddAsync(bookDto);
			return CreatedAtAction("GetBook", new { id = createdEntity.Id }, createdEntity);
		}


		// PUT: api/Books/Stock
		[HttpPut("/Api/Books/Stock/{ISBM}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult> UpdateStock(string ISBM,int totalCopies,  List<int>? bookIdsToRemove = null)
		{
			var result = await _service.UpdateStockAsync(ISBM, totalCopies, bookIdsToRemove);

			return Ok(result);
		}

		// DELETE: api/Books/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin,Worker")]
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

		// POST: api/Books/Rate/5
		[HttpPost("Rate/{id}")]
		[Authorize(Roles = "Member")]
		public async Task<IActionResult> RateBook(int id,short rate)
		{
			var userEmail = User.FindFirstValue(ClaimTypes.Email);
			
			var result = await _service.RateBook(id,rate,userEmail!);
			return Ok(result);
		}

		private async Task<bool> BookExists(int id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
