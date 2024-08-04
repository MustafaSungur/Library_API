using System.Security.Cryptography;
using System.Threading.Tasks;
using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreEmployeeRepository : EfCoreGenericRepository<Employee, libAPIContext, string>, IEmployeeRepository
	{
		public EfCoreEmployeeRepository(libAPIContext context) : base(context)
		{
		}

		public override async Task<IEnumerable<Employee>> GetAllAsync()
		{
			return await _context.Employees
				.AsNoTracking()
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u!.Gender)
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u!.Address)
						.ThenInclude(a => a.City)
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u!.Address)
						.ThenInclude(a => a.Country)
				.Include(e => e.Department)
				.Include(e => e.Shift)
				.Include(e => e.Title)
				.ToListAsync();
		}



		public override async Task<Employee?> GetByIdAsync(string id)
		{
			return await _context.Employees
				.AsTracking()
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u!.Gender)
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u!.Address)
						.ThenInclude(a => a.City)
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u!.Address)
						.ThenInclude(a => a.Country)
				.Include(e => e.Department)
				.Include(e => e.Shift)
				.Include(e => e.Title)
				.FirstOrDefaultAsync(e => e.Id == id.ToString());
		}

		public override async Task<bool> DeleteAsync(string id)
		{
			var employee = await _context.Employees
				.Include(e => e.ApplicationUser) 
				.FirstOrDefaultAsync(e => e.Id == id);

			if (employee == null || employee.ApplicationUser == null)
			{
				return false;
			}

			// Çalışanın ApplicationUser statüsünü false olarak ayarlama
			employee.ApplicationUser.Status = false;

			await _context.SaveChangesAsync();
			return true;
		}
	}
}
