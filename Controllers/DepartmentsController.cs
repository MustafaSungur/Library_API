using libAPI.DTOs;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentsController : ControllerBase
	{
		private readonly IDepartmentsService _service;

		public DepartmentsController(IDepartmentsService service)
		{
			_service = service;
		}

		// GET: api/Departments
		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<IEnumerable<DepartmentReadDTO>>> GetDepartments()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Departments/5
		[HttpGet("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<DepartmentReadDTO>> GetDepartment(short id)
		{
			var department = await _service.GetByIdAsync(id);

			if (department == null)
			{
				return NotFound();
			}

			return Ok(department);
		}

		// PUT: api/Departments/5
		[HttpPut("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> PutDepartment(short id, DepartmentCreateDTO departmentDto)
		{
			if (id != departmentDto.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(departmentDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await DepartmentExists(id))
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

		// POST: api/Departments
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<DepartmentReadDTO>> PostDepartment(DepartmentCreateDTO departmentDto)
		{
			var createdEntity = await _service.AddAsync(departmentDto);
			return CreatedAtAction("GetDepartment", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Departments/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteDepartment(short id)
		{
			var department = await _service.GetByIdAsync(id);
			if (department == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> DepartmentExists(short id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
