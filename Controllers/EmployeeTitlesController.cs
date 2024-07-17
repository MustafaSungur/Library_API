using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libAPI.DTOs;
using libAPI.Services.Abstract;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeTitlesController : ControllerBase
	{
		private readonly IEmployeeTitleService _service;

		public EmployeeTitlesController(IEmployeeTitleService service)
		{
			_service = service;
		}

		// GET: api/EmployeeTitles
		[HttpGet]
		public async Task<ActionResult<IEnumerable<EmployeeTitleDTO>>> GetEmployeeTitle()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/EmployeeTitles/5
		[HttpGet("{id}")]
		public async Task<ActionResult<EmployeeTitleDTO>> GetEmployeeTitle(short id)
		{
			var employeeTitle = await _service.GetByIdAsync(id);

			if (employeeTitle == null)
			{
				return NotFound();
			}

			return Ok(employeeTitle);
		}

		// PUT: api/EmployeeTitles/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEmployeeTitle(short id, EmployeeTitleDTO employeeTitleDto)
		{
			if (id != employeeTitleDto.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(employeeTitleDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await EmployeeTitleExists(id))
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

		// POST: api/EmployeeTitles
		[HttpPost]
		public async Task<ActionResult<EmployeeTitleDTO>> PostEmployeeTitle(EmployeeTitleDTO employeeTitleDto)
		{
			var createdEntity = await _service.AddAsync(employeeTitleDto);
			return CreatedAtAction("GetEmployeeTitle", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/EmployeeTitles/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEmployeeTitle(short id)
		{
			var employeeTitle = await _service.GetByIdAsync(id);
			if (employeeTitle == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> EmployeeTitleExists(short id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
