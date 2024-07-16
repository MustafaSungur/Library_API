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

		public override async Task<bool> DeleteAsync(string id)
		{
			var employee = await _context.Employee
				.Include(e => e.ApplicationUser) // ApplicationUser'a erişim için Include kullanılıyor
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
