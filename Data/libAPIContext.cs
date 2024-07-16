using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using libAPI.Models;

namespace libAPI.Data
{
    public class libAPIContext : DbContext
    {
        public libAPIContext (DbContextOptions<libAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AddressCity> AddressCity { get; set; } = default!;
        public DbSet<AddressCountry> AddressCountry { get; set; } = default!;
        public DbSet<Address> Address { get; set; } = default!;
        public DbSet<Genre> Genre { get; set; } = default!;
        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<EducationalDegree> EducationalDegree { get; set; } = default!;
        public DbSet<EmployeeTitle> EmployeeTitle { get; set; } = default!;
        public DbSet<Shift> Shift { get; set; } = default!;
		public DbSet<Author> Author { get; set; } = default!;
		public DbSet<Category> Category { get; set; } = default!;
		public DbSet<SubCategory> SubCategory { get; set; } = default!;
		public DbSet<Book> Book { get; set; } = default!;
		public DbSet<Language> Languages { get; set; } = default!;
		public DbSet<Location> Locations { get; set; } = default!;
		public DbSet<Stock> Stocks { get; set; } = default!;
		public DbSet<Employee> Employees { get; set; } = default!;
		public DbSet<ApplicationUser> Persons { get; set; } = default!;
		public DbSet<BorrowBooks> BorrowBooks { get; set; } = default!;
		public DbSet<Employee> Employee { get; set; } = default!;
		public DbSet<Member> Member { get; set; } = default!;
		public DbSet<Language> Language { get; set; } = default!;
		public DbSet<Publisher> Publisher { get; set; } = default!;
		public DbSet<BorrowHistory> BorrowHistories { get; set; } = default!;



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// AUTHORBOOK
			modelBuilder.Entity<AuthorBook>()
				.HasKey(ab => new { ab.AuthorId, ab.BookId });

			modelBuilder.Entity<AuthorBook>()
				.HasOne(ab => ab.Author)
				.WithMany(a => a.AuthorBooks)
				.HasForeignKey(ab => ab.AuthorId);

			modelBuilder.Entity<AuthorBook>()
				.HasOne(ab => ab.Book)
				.WithMany(b => b.AuthorBooks)
				.HasForeignKey(ab => ab.BookId);

			// LANGUAGEBOOK
			modelBuilder.Entity<LanguageBook>()
			  .HasKey(ab => new { ab.LanguageId, ab.BookId });

			modelBuilder.Entity<LanguageBook>()
				.HasOne(ab => ab.Language)
				.WithMany(a => a.LanguageBooks)
				.HasForeignKey(ab => ab.LanguageId);

			modelBuilder.Entity<LanguageBook>()
				.HasOne(ab => ab.Book)
				.WithMany(b => b.LanguageBooks)
				.HasForeignKey(ab => ab.BookId);

			// SUBCATEGORYBOOK
			modelBuilder.Entity<SubCategoryBook>()
			  .HasKey(ab => new { ab.SubCategoryId, ab.BookId });

			modelBuilder.Entity<SubCategoryBook>()
				.HasOne(ab => ab.SubCategory)
				.WithMany(a => a.SubCategoryBooks)
				.HasForeignKey(ab => ab.SubCategoryId);

			modelBuilder.Entity<SubCategoryBook>()
				.HasOne(ab => ab.Book)
				.WithMany(b => b.SubCategoryBooks)
				.HasForeignKey(ab => ab.BookId);

			
		}


	}
}
