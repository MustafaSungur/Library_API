using libAPI.DTOs;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LanguagesController : ControllerBase
	{
		private readonly ILanguageService _service;

		public LanguagesController(ILanguageService service)
		{
			_service = service;
		}

		// GET: api/Languages
		[HttpGet]
		public async Task<ActionResult<IEnumerable<LanguageDTO>>> GetLanguages()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Languages/5
		[HttpGet("{id}")]
		public async Task<ActionResult<LanguageDTO>> GetLanguage(string id)
		{
			var language = await _service.GetByIdAsync(id);

			if (language == null)
			{
				return NotFound();
			}

			return Ok(language);
		}

		// PUT: api/Languages/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutLanguage(string id, LanguageDTO language)
		{
			if (id != language.Code)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(language);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await LanguageExists(id))
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

		// POST: api/Languages
		[HttpPost]
		public async Task<ActionResult<LanguageDTO>> PostLanguage(LanguageDTO language)
		{
			try
			{
				var createdEntity = await _service.AddAsync(language);
				return CreatedAtAction("GetLanguage", new { id = createdEntity.Code }, createdEntity);
			}
			catch (DbUpdateException)
			{
				if (await LanguageExists(language.Code))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}
		}

		// DELETE: api/Languages/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteLanguage(string id)
		{
			var language = await _service.GetByIdAsync(id);
			if (language == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> LanguageExists(string id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
