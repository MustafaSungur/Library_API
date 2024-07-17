using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftsController : ControllerBase
	{
		private readonly IShiftService _service;

		public ShiftsController(IShiftService service)
		{
			_service = service;
		}

		// GET: api/Shifts
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ShiftDTO>>> GetShifts()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Shifts/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ShiftDTO>> GetShift(short id)
		{
			var shift = await _service.GetByIdAsync(id);

			if (shift == null)
			{
				return NotFound();
			}

			return Ok(shift);
		}

		// PUT: api/Shifts/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutShift(short id, ShiftDTO shift)
		{
			if (id != shift.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(shift);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await ShiftExists(id))
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

		// POST: api/Shifts
		[HttpPost]
		public async Task<ActionResult<ShiftDTO>> PostShift(ShiftDTO shift)
		{
			var createdEntity = await _service.AddAsync(shift);
			return CreatedAtAction("GetShift", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Shifts/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteShift(short id)
		{
			var shift = await _service.GetByIdAsync(id);
			if (shift == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> ShiftExists(short id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
