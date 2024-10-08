﻿using libAPI.DTOs;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly IAuthorService _service;

		public AuthorsController(IAuthorService service)
		{
			_service = service;
		}

		// GET: api/Authors
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AuthorReadDTO>>> GetAuthor()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Authors/5
		[HttpGet("{id}")]
		public async Task<ActionResult<AuthorReadDTO>> GetAuthor(long id)
		{
			var author = await _service.GetByIdAsync(id);

			if (author == null)
			{
				return NotFound();
			}

			return Ok(author);
		}

		// PUT: api/Authors/5
		[HttpPut("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> PutAuthor(long id, AuthorCreateDTO authorDto)
		{
			if (id != authorDto.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(authorDto);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!(await AuthorExists(id)))
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

		// POST: api/Authors
		[HttpPost]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<ActionResult<AuthorReadDTO>> PostAuthor(AuthorCreateDTO authorDto)
		{
			var createdEntity = await _service.AddAsync(authorDto);

			return CreatedAtAction("GetAuthor", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Authors/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin,Worker")]
		public async Task<IActionResult> DeleteAuthor(long id)
		{
			var author = await _service.GetByIdAsync((int)id);
			if (author == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync((int)id);

			return NoContent();
		}

		private async Task<bool> AuthorExists(long id)
		{
			return (await _service.GetByIdAsync((int)id)) != null;
		}
	}
}
