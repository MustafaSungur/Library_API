using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libAPI.DTOs;
using libAPI.Services.Abstract;

namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase
	{
		private readonly IAddressService _service;

		public AddressesController(IAddressService service)
		{
			_service = service;
		}

		// GET: api/Addresses
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AddressReadDTO>>> GetAddress()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Addresses/5
		[HttpGet("{id}")]
		public async Task<ActionResult<AddressReadDTO>> GetAddress(int id)
		{
			var address = await _service.GetByIdAsync(id);

			if (address == null)
			{
				return NotFound();
			}

			return Ok(address);
		}

		// PUT: api/Addresses/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAddress(int id, AddressCreateDTO addressDto)
		{
			if (id != addressDto.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(addressDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!(await AddressExists(id)))
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

		// POST: api/Addresses
		[HttpPost]
		public async Task<ActionResult<AddressReadDTO>> PostAddress(AddressCreateDTO addressDto)
		{
			var createdEntity = await _service.AddAsync(addressDto);

			return CreatedAtAction("GetAddress", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Addresses/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAddress(int id)
		{
			var address = await _service.GetByIdAsync(id);
			if (address == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);

			return NoContent();
		}

		private async Task<bool> AddressExists(int id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
