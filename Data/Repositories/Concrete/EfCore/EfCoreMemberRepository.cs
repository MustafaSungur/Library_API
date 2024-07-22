using libAPI.Data.Repositories.Abstract;
using libAPI.Models;
using Microsoft.EntityFrameworkCore;
using ShopApp.data.Concrete.EfCore;

namespace libAPI.Data.Repositories.Concrete.EfCore
{
	public class EfCoreMemberRepository : EfCoreGenericRepository<Member, libAPIContext,string>,IMemberRepository
	{
		public EfCoreMemberRepository(libAPIContext context) : base(context)
		{
		}


		public override async Task<IEnumerable<Member>> GetAllAsync()
		{
			return await _context.Member
				 .AsTracking()
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u.Gender)
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u.Address)
						.ThenInclude(a => a.City)
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u.Address)
						.ThenInclude(a => a.Country)
				//.Include(e=>e.BorrowingHistory).ThenInclude(bh=>bh.Employee)
				.Include(e=>e.EducationalDegree)
				.ToListAsync();
		}

		public override async Task<Member?> GetByIdAsync(string id)
		{
			return await _context.Member
				.AsTracking()
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u.Gender)
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u.Address)
						.ThenInclude(a => a.City)
				.Include(e => e.ApplicationUser)
					.ThenInclude(u => u.Address)
						.ThenInclude(a => a.Country)
				//.Include(e => e.BorrowingHistory).ThenInclude(bh => bh.Employee)
				.Include(e => e.EducationalDegree)
				.FirstOrDefaultAsync(e => e.Id == id.ToString());
		}

		public override async Task<bool> DeleteAsync(string id)
		{
			var member = await _context.Member
				.Include(e => e.ApplicationUser)
		
				.FirstOrDefaultAsync(e => e.Id == id);

			if (member == null || member.ApplicationUser == null)
			{
				return false;
			}

			// Çalışanın ApplicationUser statüsünü false olarak ayarlama
			member.ApplicationUser.Status = false;

			await _context.SaveChangesAsync();
			return true;
		}
	}
}
