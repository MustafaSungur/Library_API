
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressesController(IAddressService service)
        {
            _service = service;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _service.GetByIdAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }


            try
            {
                await _service.UpdateAsync(address);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await AddressExists(id)))
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

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            var createdEntity = await _service.AddAsync(address);

            return CreatedAtAction("GetAddress", new { id = createdEntity.Id }, createdEntity);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _service.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> AddressExists(int id)
        {
            return (await _service.GetByIdAsync(id)) != null;
        }
    }
}
