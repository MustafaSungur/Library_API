
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _servcice;

        public EmployeesController(IEmployeeService service)
        {
            _servcice = service;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            var result = await _servcice.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            var employee = await _servcice.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }


            try
            {
                await _servcice.UpdateAsync(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EmployeeExists(id))
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

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
			var createdEntity= await _servcice.AddAsync(employee);                 

            return CreatedAtAction("GetEmployee", new { id = createdEntity.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var employee = await _servcice.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

           
            await _servcice.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> EmployeeExists(string id)
        {
            return (await _servcice.GetByIdAsync(id)) != null;
        }
    }
}
