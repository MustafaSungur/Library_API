using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EducationalDegreesController : ControllerBase
	{
		private readonly IEducationalDegreeService _service;

		public EducationalDegreesController(IEducationalDegreeService service)
		{
			_service = service;
		}

		// GET: api/EducationalDegrees
		[HttpGet]
		public async Task<ActionResult<IEnumerable<EducationalDegree>>> GetEducationalDegrees()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/EducationalDegrees/5
		[HttpGet("{id}")]
		public async Task<ActionResult<EducationalDegree>> GetEducationalDegree(short id)
		{
			var educationalDegree = await _service.GetByIdAsync(id);

			if (educationalDegree == null)
			{
				return NotFound();
			}

			return educationalDegree;
		}

		// PUT: api/EducationalDegrees/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEducationalDegree(short id, EducationalDegree educationalDegree)
		{
			if (id != educationalDegree.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(educationalDegree);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await EducationalDegreeExists(id))
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

		// POST: api/EducationalDegrees
		[HttpPost]
		public async Task<ActionResult<EducationalDegree>> PostEducationalDegree(EducationalDegree educationalDegree)
		{
			var createdEntity = await _service.AddAsync(educationalDegree);
			return CreatedAtAction("GetEducationalDegree", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/EducationalDegrees/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEducationalDegree(short id)
		{
			var educationalDegree = await _service.GetByIdAsync(id);
			if (educationalDegree == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> EducationalDegreeExists(short id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
