using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressCitiesController : ControllerBase
	{
		private readonly IAddressCityService _service;

		public AddressCitiesController(IAddressCityService service)
		{
			_service = service;
		}

		// GET: api/AddressCities
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AddressCity>>> GetAddressCity()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/AddressCities/5
		[HttpGet("{id}")]
		public async Task<ActionResult<AddressCity>> GetAddressCity(int id)
		{
			var addressCity = await _service.GetByIdAsync(id);

			if (addressCity == null)
			{
				return NotFound();
			}

			return addressCity;
		}

		// PUT: api/AddressCities/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAddressCity(int id, AddressCity addressCity)
		{
			if (id != addressCity.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(addressCity);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await AddressCityExists(id))
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

		// POST: api/AddressCities
		[HttpPost]
		public async Task<ActionResult<AddressCity>> PostAddressCity(AddressCity addressCity)
		{
			var createdEntity = await _service.AddAsync(addressCity);
			return CreatedAtAction("GetAddressCity", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/AddressCities/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAddressCity(int id)
		{
			var addressCity = await _service.GetByIdAsync(id);
			if (addressCity == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> AddressCityExists(int id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
