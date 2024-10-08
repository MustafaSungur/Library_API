﻿using libAPI.DTOs;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PublishersController : ControllerBase
	{
		private readonly IPublisherService _service;

		public PublishersController(IPublisherService service)
		{
			_service = service;
		}

		// GET: api/Publishers
		[HttpGet]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<IEnumerable<PublisherReadDTO>>> GetPublishers()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Publishers/5
		[HttpGet("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<PublisherReadDTO>> GetPublisher(int id)
		{
			var publisher = await _service.GetByIdAsync(id);

			if (publisher == null)
			{
				return NotFound();
			}

			return Ok(publisher);
		}

		// PUT: api/Publishers/5
		[HttpPut("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> PutPublisher(int id, PublisherCreateDTO publisher)
		{
			if (id != publisher.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(publisher);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await PublisherExists(id))
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

		// POST: api/Publishers
		[HttpPost]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<PublisherReadDTO>> PostPublisher(PublisherCreateDTO publisher)
		{
			var createdEntity = await _service.AddAsync(publisher);
			return CreatedAtAction("GetPublisher", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Publishers/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> DeletePublisher(int id)
		{
			var publisher = await _service.GetByIdAsync(id);
			if (publisher == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> PublisherExists(int id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
