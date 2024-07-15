using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libAPI.Models;
using libAPI.Services.Abstract;

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
        public async Task<ActionResult<IEnumerable<AddressCountry>>> GetAddressCountry()
        {
            var results = await _service.GetAllAsync();
            return Ok(results);
        }

        // GET: api/AddressCountries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressCountry>> GetAddressCountry(short id)
        {
            var addressCountry = await _service.GetByIdAsync(id);

            if (addressCountry == null)
            {
                return NotFound();
            }

            return addressCountry;
        }

        // PUT: api/AddressCountries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressCountry(short id, AddressCountry addressCountry)
        {
            if (id != addressCountry.Id)
            {
                return BadRequest();
            }
            
            try
            {
                await _service.UpdateAsync(addressCountry);
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddressCountry>> PostAddressCountry(AddressCountry addressCountry)
        {
            var createdEntity = await _service.AddAsync(addressCountry);

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
            return (await _service.GetByIdAsync(id))!= null;
        }
    }
}
