using System;
using System.ComponentModel.DataAnnotations;
using libAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
namespace libAPI.Models
{
	public class Category
	{
		public short Id { get; set; }

		[StringLength(50)]
		public required string Name { get; set; } 

		public List<SubCategory>? SubCategories{ get; set; }
	}

}