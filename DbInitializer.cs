using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using libAPI.Data;
using libAPI.Models;


namespace libAPI
{
	public static class DbInitializer
	{
		public static async Task InitializeAsync(IServiceProvider serviceProvider)
		{
			using var scope = serviceProvider.CreateScope();
			var scopedProvider = scope.ServiceProvider;

			var context = scopedProvider.GetRequiredService<libAPIContext>();
			var roleManager = scopedProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = scopedProvider.GetRequiredService<UserManager<ApplicationUser>>();

			await context.Database.MigrateAsync();


			if ((await context.AddressCity.FirstOrDefaultAsync(e => e.Name == "İstanbul")) == null)
			{
				var addressCity = new AddressCity {  Name = "İstanbul" };
				context.AddressCity!.Add(addressCity);
				await context.SaveChangesAsync();
			}
			if ((await context.AddressCountry.FirstOrDefaultAsync(e => e.Name == "Türkiye")) == null)
			{
				var addressCountry = new AddressCountry { Name = "Türkiye" };
				context.AddressCountry!.Add(addressCountry);
				await context.SaveChangesAsync();
			}
			if ((await context.Address.FirstOrDefaultAsync(e => e.ClearAddress == "AdminAddress")) == null)
			{
				var addressCity = await context.AddressCity.FirstOrDefaultAsync(e => e.Name == "İstanbul");
				var addressCountry =await context.AddressCountry.FirstOrDefaultAsync(e => e.Name == "Türkiye");
				var Address= new Address { AddressCityId =(short)addressCity.Id,AddressCountryId=(short)addressCountry.Id,ClearAddress="AdminAddress"};
				await context.Address!.AddAsync(Address);
				await context.SaveChangesAsync();
			}
			if ((await context.Genre.FirstOrDefaultAsync(e => e.Name == "Erkek")) == null)
			{
				var genre = new Genre { Name = "Erkek" };
				context.Genre!.Add(genre);
				await context.SaveChangesAsync();
			}
			if (await roleManager.FindByNameAsync("Admin") == null)
			{
				var identityRole = new IdentityRole("Admin");
				await roleManager.CreateAsync(identityRole);
			}
			if (await roleManager.FindByNameAsync("Worker") == null)
			{
				var identityRole2 = new IdentityRole("Worker");
				await roleManager.CreateAsync(identityRole2);

			}
			if (await userManager.FindByNameAsync("Admin") == null)
			{
				var address = await context.Address.FirstOrDefaultAsync(e => e.ClearAddress == "AdminAddress");
				var genre = await context.Genre.FirstOrDefaultAsync(e => e.Name == "Erkek");
				var applicationUser = new ApplicationUser { UserName = "Admin", AddressId = address!.Id, GenderId = genre!.Id, RegisterDate = DateTime.Now,BirthDate=new DateTime(1999,1,12) };
				await userManager.CreateAsync(applicationUser, "Admin123!");
				await userManager.AddToRoleAsync(applicationUser, "Admin");
			}
			if (await context.Language!.FindAsync("tr") == null)
			{
				var language = new Language { Code = "tr", Name = "Türkçe" };
				context.Language!.Add(language);
				await context.SaveChangesAsync();


			}
		}
	}
}
