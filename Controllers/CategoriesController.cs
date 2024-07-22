using libAPI.DTOs;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _service;

		public CategoriesController(ICategoryService service)
		{
			_service = service;
		}

		// GET: api/Categories
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CategoryReadDTO>>> GetCategories()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Categories/5
		[HttpGet("{id}")]
		public async Task<ActionResult<CategoryReadDTO>> GetCategory(short id)
		{
			var category = await _service.GetByIdAsync(id);

			if (category == null)
			{
				return NotFound();
			}

			return Ok(category);
		}

		// PUT: api/Categories/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCategory(short id, CategoryCreateDTO categoryDto)
		{
			if (id != categoryDto.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(categoryDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await CategoryExists(id))
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

		// POST: api/Categories
		[HttpPost]
		public async Task<ActionResult<CategoryReadDTO>> PostCategory(CategoryCreateDTO categoryDto)
		{
			var createdEntity = await _service.AddAsync(categoryDto);
			return CreatedAtAction("GetCategory", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Categories/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(short id)
		{
			var category = await _service.GetByIdAsync(id);
			if (category == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> CategoryExists(short id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
