using libAPI.DTOs;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationsController : ControllerBase
	{
		private readonly ILocationService _service;

		public LocationsController(ILocationService service)
		{
			_service = service;
		}

		// GET: api/Locations
		[HttpGet]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<IEnumerable<LocationReadDTO>>> GetLocations()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Locations/5
		[HttpGet("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<LocationReadDTO>> GetLocation(int id)
		{
			var location = await _service.GetByIdAsync(id);

			if (location == null)
			{
				return NotFound();
			}

			return Ok(location);
		}

		// PUT: api/Locations/5
		[HttpPut("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> PutLocation(int id, LocationCreateDTO location)
		{
			if (id != location.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(location);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await LocationExists(id))
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

		// POST: api/Locations
		[HttpPost]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<LocationReadDTO>> PostLocation(LocationCreateDTO location)
		{
			var createdEntity = await _service.AddAsync(location);
			return CreatedAtAction("GetLocation", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Locations/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> DeleteLocation(int id)
		{
			var location = await _service.GetByIdAsync(id);
			if (location == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> LocationExists(int id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
