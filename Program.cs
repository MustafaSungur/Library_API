using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using libAPI.Data;
using libAPI.Controllers;
using libAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace libAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<libAPIContext>(options =>
			    options.UseSqlServer(builder.Configuration.GetConnectionString("libAPIContext") ?? throw new InvalidOperationException("Connection string 'libAPIContext' not found.")));			

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

               if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

            
			app.Run();
		}
	}
}
