﻿using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenresController : ControllerBase
	{
		private readonly IGenreService _service;

		public GenresController(IGenreService service)
		{
			_service = service;
		}

		// GET: api/Genres
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/Genres/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Genre>> GetGenre(short id)
		{
			var genre = await _service.GetByIdAsync(id);

			if (genre == null)
			{
				return NotFound();
			}

			return genre;
		}

		// PUT: api/Genres/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutGenre(short id, Genre genre)
		{
			if (id != genre.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(genre);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await GenreExists(id))
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

		// POST: api/Genres
		[HttpPost]
		public async Task<ActionResult<Genre>> PostGenre(Genre genre)
		{
			var createdEntity = await _service.AddAsync(genre);
			return CreatedAtAction("GetGenre", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/Genres/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteGenre(short id)
		{
			var genre = await _service.GetByIdAsync(id);
			if (genre == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> GenreExists(short id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}