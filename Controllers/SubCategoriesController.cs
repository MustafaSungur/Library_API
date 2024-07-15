﻿using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubCategoriesController : ControllerBase
	{
		private readonly ISubCategoryService _service;

		public SubCategoriesController(ISubCategoryService service)
		{
			_service = service;
		}

		// GET: api/SubCategories
		[HttpGet]
		public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategories()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		// GET: api/SubCategories/5
		[HttpGet("{id}")]
		public async Task<ActionResult<SubCategory>> GetSubCategory(short id)
		{
			var subCategory = await _service.GetByIdAsync(id);

			if (subCategory == null)
			{
				return NotFound();
			}

			return subCategory;
		}

		// PUT: api/SubCategories/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutSubCategory(short id, SubCategory subCategory)
		{
			if (id != subCategory.Id)
			{
				return BadRequest();
			}

			try
			{
				await _service.UpdateAsync(subCategory);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await SubCategoryExists(id))
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

		// POST: api/SubCategories
		[HttpPost]
		public async Task<ActionResult<SubCategory>> PostSubCategory(SubCategory subCategory)
		{
			var createdEntity = await _service.AddAsync(subCategory);
			return CreatedAtAction("GetSubCategory", new { id = createdEntity.Id }, createdEntity);
		}

		// DELETE: api/SubCategories/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSubCategory(short id)
		{
			var subCategory = await _service.GetByIdAsync(id);
			if (subCategory == null)
			{
				return NotFound();
			}

			await _service.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> SubCategoryExists(short id)
		{
			return (await _service.GetByIdAsync(id)) != null;
		}
	}
}
