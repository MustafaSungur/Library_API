
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTitlesController : ControllerBase
    {
        private readonly IEmployeeTitleService _service;

        public EmployeeTitlesController(IEmployeeTitleService service)
        {
            _service = service;
        }

        // GET: api/EmployeeTitles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTitle>>> GetEmployeeTitle()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);  
        }

        // GET: api/EmployeeTitles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTitle>> GetEmployeeTitle(short id)
        {
            var employeeTitle = await _service.GetByIdAsync(id);

            if (employeeTitle == null)
            {
                return NotFound();
            }

            return employeeTitle;
        }

        // PUT: api/EmployeeTitles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeTitle(short id, EmployeeTitle employeeTitle)
        {
            if (id != employeeTitle.Id)
            {
                return BadRequest();
            }


            try
            {
                await _service.GetByIdAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await EmployeeTitleExists(id))
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
        [HttpPost]
        public async Task<ActionResult<EmployeeTitle>> PostEmployeeTitle(EmployeeTitle employeeTitle)
        {
            var createdEntity = await _service.AddAsync(employeeTitle);

            return CreatedAtAction("GetEmployeeTitle", new { id = createdEntity.Id }, createdEntity);
        }

        // DELETE: api/EmployeeTitles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeTitle(short id)
        {
            var employeeTitle = await _service.GetByIdAsync(id);
            if (employeeTitle == null)
            {
                return NotFound();
            }

            
            await _service.DeleteAsync(id);

            return NoContent();
        }


		private async Task<bool> EmployeeTitleExists(short id)
		{
            
			return (await _service.GetByIdAsync(id)) != null;
		}

	}
}
