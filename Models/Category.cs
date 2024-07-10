using System;
using libAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
namespace libAPI.Models
{
	public class Category
	{
		public short Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public List<SubCategory>? SubCategories{ get; set; }
	}

}