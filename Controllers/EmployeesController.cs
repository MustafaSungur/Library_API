using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libAPI.DTOs;
using libAPI.Services.Abstract;
using libAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


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
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<IEnumerable<EmployeeReadDTO>>> GetEmployee()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Employees/5
		[HttpGet("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<EmployeeReadDTO>> GetEmployee(string id)
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
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> PutEmployee(string id, EmployeeCreateDTO employeeDto)
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
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<EmployeeReadDTO>> PostEmployee(EmployeeCreateDTO employeeDto)
		{
			var createdEntity = await _service.AddAsync(employeeDto);
			return CreatedAtAction("GetEmployee", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Employees/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
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
