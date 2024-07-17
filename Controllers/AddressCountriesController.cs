﻿using libAPI.DTOs;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressCountriesController : ControllerBase
	{
		private readonly IAddressCountryService _service;

		public AddressCountriesController(IAddressCountryService service)
		{
			_service = service;
		}

		// GET: api/AddressCountries
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AddressCountryDTO>>> GetAddressCountry()
		{
			var results = await _service.GetAllAsync();
			return Ok(results);
		}

		// GET: api/AddressCountries/5
		[HttpGet("{id}")]
		public async Task<ActionResult<AddressCountryDTO>> GetAddressCountry(short id)
		{
			var addressCountry = await _service.GetByIdAsync(id);

			if (addressCountry == null)
			{
				return NotFound();
			}

			return Ok(addressCountry);
		}

		// PUT: api/AddressCountries/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAddressCountry(short id, AddressCountryDTO addressCountryDto)
		{
			if (id != addressCountryDto.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(addressCountryDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!(await AddressCountryExists(id)))
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

		// POST: api/AddressCountries
		[HttpPost]
		public async Task<ActionResult<AddressCountryDTO>> PostAddressCountry(AddressCountryDTO addressCountryDto)
		{
			var createdEntity = await _service.AddAsync(addressCountryDto);

			return CreatedAtAction("GetAddressCountry", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/AddressCountries/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAddressCountry(short id)
		{
			var addressCountry = await _service.GetByIdAsync(id);
			if (addressCountry == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);

			return NoContent();
		}

		private async Task<bool> AddressCountryExists(short id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
