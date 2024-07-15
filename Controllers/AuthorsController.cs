
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libAPI.Models;
using libAPI.Services.Abstract;

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
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthor()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(long id)
        {
            var author = await _service.GetByIdAsync((int)id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(long id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }


            try
            {
                await _service.UpdateAsync(author);
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
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            var createdEntity = await _service.AddAsync(author);

            return CreatedAtAction("GetAuthor", new { id = createdEntity.Id }, createdEntity);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
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
            return (await _service.GetByIdAsync((int)id))!=null;
        }
    }
}
