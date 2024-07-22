using System.Threading.Tasks;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreAddressRepository : EfCoreGenericRepository<Address, libAPIContext, int>, IAddressRepository
	{
		public EfCoreAddressRepository(libAPIContext context) : base(context)
		{
		}

		public override async Task<IEnumerable<Address>> GetAllAsync()
		{
			return await _context.Address
				.Include(e => e.City)
				.Include(e => e.Country)
				.ToListAsync();
		}

		public override async Task<Address?> GetByIdAsync(int id)
		{
			return await _context.Address
				.Include(e => e.City)
				.Include(e => e.Country)
				.FirstOrDefaultAsync(e => e.Id == id);
		}

		public override async Task<Address> AddAsync(Address address)
		{
			await _context.Address.AddAsync(address);
			await _context.SaveChangesAsync();

			// Reload the entity with related data
			return await _context.Address
				.Include(e => e.City)
				.Include(e => e.Country)
				.FirstOrDefaultAsync(e => e.Id == address.Id);
		}

		public override async Task<bool> DeleteAsync(int id)
		{
			var address = await _context.Address.FindAsync(id);

			if (address == null)
			{
				return false;
			}

			_context.Address.Remove(address);
			await _context.SaveChangesAsync();
			return true;
		}

		public void DetachEntity(Address address)
		{
			var entity = _context.Entry(address);
			if (entity != null)
			{
				entity.State = EntityState.Detached;
			}
		}
	}
}
