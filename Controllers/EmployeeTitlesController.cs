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
    public class EmployeeTitlesController : ControllerBase
    {
        private readonly libAPIContext _context;

        public EmployeeTitlesController(libAPIContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeTitles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTitle>>> GetEmployeeTitle()
        {
            return await _context.EmployeeTitle.ToListAsync();
        }

        // GET: api/EmployeeTitles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTitle>> GetEmployeeTitle(short id)
        {
            var employeeTitle = await _context.EmployeeTitle.FindAsync(id);

            if (employeeTitle == null)
            {
                return NotFound();
            }

            return employeeTitle;
        }

        // PUT: api/EmployeeTitles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeTitle(short id, EmployeeTitle employeeTitle)
        {
            if (id != employeeTitle.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeTitle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTitleExists(id))
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

        // POST: api/EmployeeTitles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeTitle>> PostEmployeeTitle(EmployeeTitle employeeTitle)
        {
            _context.EmployeeTitle.Add(employeeTitle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeTitle", new { id = employeeTitle.Id }, employeeTitle);
        }

        // DELETE: api/EmployeeTitles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeTitle(short id)
        {
            var employeeTitle = await _context.EmployeeTitle.FindAsync(id);
            if (employeeTitle == null)
            {
                return NotFound();
            }

            _context.EmployeeTitle.Remove(employeeTitle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeTitleExists(short id)
        {
            return _context.EmployeeTitle.Any(e => e.Id == id);
        }
    }
}
