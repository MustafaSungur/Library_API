using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libAPI.DTOs;
using libAPI.Services.Abstract;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeService _service;

		public EmployeesController(IEmployeeService service)
		{
			_service = service;
		}

		// GET: api/Employees
		[HttpGet]
		public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployee()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Employees/5
		[HttpGet("{id}")]
		public async Task<ActionResult<EmployeeDTO>> GetEmployee(string id)
		{
			var employee = await _service.GetByIdAsync(id);

			if (employee == null)
			{
				return NotFound();
			}

			return Ok(employee);
		}

		// PUT: api/Employees/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEmployee(string id, EmployeeDTO employeeDto)
		{
			if (id != employeeDto.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(employeeDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await EmployeeExists(id))
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

		// POST: api/Employees
		[HttpPost]
		public async Task<ActionResult<EmployeeDTO>> PostEmployee(EmployeeDTO employeeDto)
		{
			var createdEntity = await _service.AddAsync(employeeDto);
			return CreatedAtAction("GetEmployee", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Employees/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEmployee(string id)
		{
			var employee = await _service.GetByIdAsync(id);
			if (employee == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> EmployeeExists(string id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
