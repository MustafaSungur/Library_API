using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libAPI.DTOs;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Authorization;


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
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<IEnumerable<EmployeeTitleReadDTO>>> GetEmployeeTitle()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/EmployeeTitles/5
		[HttpGet("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<EmployeeTitleReadDTO>> GetEmployeeTitle(short id)
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
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> PutEmployeeTitle(short id, EmployeeTitleCreateDTO employeeTitleDto)
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
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<EmployeeTitleReadDTO>> PostEmployeeTitle(EmployeeTitleCreateDTO employeeTitleDto)
		{
			var createdEntity = await _service.AddAsync(employeeTitleDto);
			return CreatedAtAction("GetEmployeeTitle", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/EmployeeTitles/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
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
