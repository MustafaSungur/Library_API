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
				var addressCity = new AddressCity { Name = "İstanbul" };
				context.AddressCity!.Add(addressCity);
				await context.SaveChangesAsync();
			}
			if ((await context.AddressCountry.FirstOrDefaultAsync(e => e.Name == "Türkiye")) == null)
			{
				var addressCountry = new AddressCountry { Name = "Türkiye" };
				context.AddressCountry!.Add(addressCountry);
				await context.SaveChangesAsync();
			}
			
			if ((await context.Genre.FirstOrDefaultAsync(e => e.Name == "Erkek")) == null)
			{
				var genre = new Genre { Name = "Erkek" };
				context.Genre!.Add(genre);
				await context.SaveChangesAsync();
			}

			// Örnek başlangıç verileri için Title ve Department tabloları
			if (!context.EmployeeTitle.Any())
			{
				var titles = new List<EmployeeTitle>
				{
					new EmployeeTitle { Name = "Manager" },
				};
				context.EmployeeTitle.AddRange(titles);
				await context.SaveChangesAsync();
			}
			if (!context.Department.Any())
			{
				var departments = new List<Department>
				{
					new Department { Name = "Manager" },
				};
				context.Department.AddRange(departments);
				await context.SaveChangesAsync();
			}
			if (!context.Shift.Any())
			{
				var shift = new List<Shift>
				{
					new Shift { Name = "Gündüz" },
				};
				context.Shift.AddRange(shift);
				await context.SaveChangesAsync();
			}
			// Diğer başlangıç verileriniz burada yer alabilir
			if (!context.Address.Any(e => e.ClearAddress == "AdminAddress"))
			{
				var addressCity = await context.AddressCity.FirstOrDefaultAsync(e => e.Name == "İstanbul");
				var addressCountry = await context.AddressCountry.FirstOrDefaultAsync(e => e.Name == "Türkiye");
				var address = new Address { AddressCityId = (short)addressCity.Id, AddressCountryId = (short)addressCountry.Id, ClearAddress = "AdminAddress" };
				context.Address.Add(address);
				await context.SaveChangesAsync();
			}


			if (await roleManager.FindByNameAsync("Admin") == null)
			{
				var identityRole = new IdentityRole("Admin");
				await roleManager.CreateAsync(identityRole);
			}
			if (await roleManager.FindByNameAsync("Worker") == null)
			{
				var identityRole = new IdentityRole("Worker");
				await roleManager.CreateAsync(identityRole);

			}
			if (await roleManager.FindByNameAsync("Member") == null)
			{
				var identityRole = new IdentityRole("Member");
				await roleManager.CreateAsync(identityRole);

			}


			if (!context.Employees.Any())
			{
				var address = await context.Address.FirstOrDefaultAsync(e => e.ClearAddress == "AdminAddress");
				var genre = await context.Genre.FirstOrDefaultAsync(e => e.Name == "Erkek");
				var applicationUser = new ApplicationUser
				{
					FirstName="Admin",
					LastName = "Admin",
					UserName = "Admin",
					Email = "admin@admin.com",
					AddressId = address.Id,
					GenderId = genre.Id,
					RegisterDate = DateTime.Now,
					BirthDate = new DateTime(1999, 1, 12),

				};
				await userManager.CreateAsync(applicationUser, "Admin123!");
				await userManager.AddToRoleAsync(applicationUser, "Admin");
				var employee = new Employee
				{
					TitleId = 1, 
					DepartmentId = 1,
					Salary = 14587,
					ShiftId = 1,
					ApplicationUser = applicationUser
					
				};
				await context.Employees.AddAsync(employee);
				await context.SaveChangesAsync();

			
			}
		}
	}
}
