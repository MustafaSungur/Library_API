using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libAPI.Data;
using libAPI.Models;

namespace libAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationalDegreesController : ControllerBase
    {
        private readonly libAPIContext _context;

        public EducationalDegreesController(libAPIContext context)
        {
            _context = context;
        }

        // GET: api/EducationalDegrees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationalDegree>>> GetEducationalDegree()
        {
            return await _context.EducationalDegree.ToListAsync();
        }

        // GET: api/EducationalDegrees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationalDegree>> GetEducationalDegree(short id)
        {
            var educationalDegree = await _context.EducationalDegree.FindAsync(id);

            if (educationalDegree == null)
            {
                return NotFound();
            }

            return educationalDegree;
        }

        // PUT: api/EducationalDegrees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationalDegree(short id, EducationalDegree educationalDegree)
        {
            if (id != educationalDegree.Id)
            {
                return BadRequest();
            }

            _context.Entry(educationalDegree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationalDegreeExists(id))
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

        // POST: api/EducationalDegrees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EducationalDegree>> PostEducationalDegree(EducationalDegree educationalDegree)
        {
            _context.EducationalDegree.Add(educationalDegree);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationalDegree", new { id = educationalDegree.Id }, educationalDegree);
        }

        // DELETE: api/EducationalDegrees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationalDegree(short id)
        {
            var educationalDegree = await _context.EducationalDegree.FindAsync(id);
            if (educationalDegree == null)
            {
                return NotFound();
            }

            _context.EducationalDegree.Remove(educationalDegree);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EducationalDegreeExists(short id)
        {
            return _context.EducationalDegree.Any(e => e.Id == id);
        }
    }
}
