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

		public override async Task<bool> DeleteAsync(string id)
		{
			var member = await _context.Member
				.Include(e => e.ApplicationUser) // ApplicationUser'a erişim için Include kullanılıyor
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
