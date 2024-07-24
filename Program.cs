using Microsoft.EntityFrameworkCore;
using libAPI;
using Microsoft.AspNetCore.Identity;
using libAPI.Data;
using libAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using libAPI.Data.Repositories.Abstract;
using libAPI.Services.Abstract;
using ShopApp.data.Concrete.EfCore;
using libAPI.Data.Repositories.Concrete.EfCore;
using libAPI.Data.Repositories.Concrete;
using libAPI.Services.Concrete;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.OpenApi.Models;

namespace libAPI
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<libAPIContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("libAPIContext") ?? throw new InvalidOperationException("Connection string 'libAPIContext' not found.")));

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<libAPIContext>()
				.AddDefaultTokenProviders();

			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = builder.Configuration["Jwt:Issuer"],
					ValidAudience = builder.Configuration["Jwt:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
				};
			});


			// Add repository and service dependencies
			// Repositories
			builder.Services.AddScoped<IAddressRepository, EfCoreAddressRepository>();
			builder.Services.AddScoped<IAddressCountryRepository, EfCoreAddressCountryRepository>();
			builder.Services.AddScoped<IAddressCityRepository, EFCoreAddressCityRepository>();
			builder.Services.AddScoped<IBookRepository, EfCoreBookRepository>();
			builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
			builder.Services.AddScoped<IDepartmentRepository, EfCoreDepartmentRepository>();
			builder.Services.AddScoped<IEmployeeRepository, EfCoreEmployeeRepository>();
			builder.Services.AddScoped<IEmployeeTitleRepository, EfCoreEmployeeTitleRepository>();
			builder.Services.AddScoped<IGenreRepository, EfCoreGenreRepository>();
			builder.Services.AddScoped<ILanguageRepository, EfCoreLanguageRepository>();
			builder.Services.AddScoped<ILocationRepository, EfCoreLocationRepository>();
			builder.Services.AddScoped<IMemberRepository, EfCoreMemberRepository>();
			builder.Services.AddScoped<IPublisherRepository, EfCorePublisherRepository>();
			builder.Services.AddScoped<IShiftRepository, EfCoreShiftRepository>();
			builder.Services.AddScoped<ISubCategoryRepository, EfCoreSubCategoryRepository>();
			builder.Services.AddScoped<IAuthorRepository, EfCoreAuthorRepository>();
			builder.Services.AddScoped<IStockRepository, EfCoreStockRepository>();
			builder.Services.AddScoped<IBorrowBooksRepository, EfCoreBorrowBooksRepository>();
			builder.Services.AddScoped<IBorrowHistoryRepository, EfCoreBorrowHistoryRepository>();
			builder.Services.AddScoped<IEducationalDegreeRepository, EfCoreEducationalDegreeRepository>();
			builder.Services.AddScoped<IAuthorBookRepository, EfCoreAuthorBookRepository>();
			builder.Services.AddScoped<ILanguageBookRepository, EfCoreLanguageBookRepository>();
			builder.Services.AddScoped<ISubCategoryBookRepository, EfCoreSubCategoryBookRepository>();

			// Services
			builder.Services.AddScoped<IAddressService, AddressManager>();
			builder.Services.AddScoped<IAddressCityService, AddressCityManager>();
			builder.Services.AddScoped<IAddressCountryService, AddressCountryManager>();
			builder.Services.AddScoped<IEmployeeService, EmployeeManager>();
			builder.Services.AddScoped<IEmployeeTitleService, EmployeeTitleManager>();
			builder.Services.AddScoped<IDepartmentsService, DepartmentManager>();
			builder.Services.AddScoped<IGenreService, GenreManager>();
			builder.Services.AddScoped<IEducationalDegreeService, EducationalDegreeManager>();
			builder.Services.AddScoped<ILocationService, LocationManager>();
			builder.Services.AddScoped<IBookService, BookManager>();
			builder.Services.AddScoped<ILanguageService, LanguageManager>();
			builder.Services.AddScoped<IPublisherService, PublisherManager>();
			builder.Services.AddScoped<ICategoryService, CategoryManager>();
			builder.Services.AddScoped<IMemberService, MemberManager>();
			builder.Services.AddScoped<ISubCategoryService, SubCategoryManager>();
			builder.Services.AddScoped<IShiftService, ShiftManager>();
			builder.Services.AddScoped<IAuthorService, AuthorManager>();
			builder.Services.AddScoped<IStockService, StockManager>();
			builder.Services.AddScoped<IBorrowBooksService, BorrowBooksManager>();
			builder.Services.AddScoped<IBorrowHistoryService, BorrowHistoryManager>();
			builder.Services.AddScoped<IAuthorBookService, AuthorBookManager>();
			builder.Services.AddScoped<ILanguageBookService, LanguageBookManager>();
			builder.Services.AddScoped<ISubcategoryBookService, SubcategoryBookManager>();
			builder.Services.AddScoped<ITokenService,TokenManager>();

			// Register generic repository and service
			builder.Services.AddScoped(typeof(IRepository<,,>), typeof(EfCoreGenericRepository<,,>));
			builder.Services.AddScoped(typeof(IService<,,,,>), typeof(GenericManager<,,,,>));

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please insert JWT with Bearer into field",
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement {
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						}
					},
					new string[] { }
				}});
						});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCors("AllowAll");
			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			// Initial variables
			await DbInitializer.InitializeAsync(app.Services);

			app.Run();
		}
	}
}
