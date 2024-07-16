﻿using libAPI.Models;
using libAPI.Services.Abstract;
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
		public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Departments/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Department>> GetDepartment(short id)
		{
			var department = await _service.GetByIdAsync(id);

			if (department == null)
			{
				return NotFound();
			}

			return department;
		}

		// PUT: api/Departments/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutDepartment(short id, Department department)
		{
			if (id != department.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(department);
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
		public async Task<ActionResult<Department>> PostDepartment(Department department)
		{
			var createdEntity = await _service.AddAsync(department);
			return CreatedAtAction("GetDepartment", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Departments/5
		[HttpDelete("{id}")]
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