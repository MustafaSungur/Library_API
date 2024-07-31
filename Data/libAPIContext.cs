
using Microsoft.EntityFrameworkCore;
using libAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace libAPI.Data
{
    public class libAPIContext : IdentityDbContext<ApplicationUser>
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
		public DbSet<AuthorBook> AuthorBooks { get; set; } = default!;
		public DbSet<Category> Category { get; set; } = default!;
		public DbSet<SubCategory> SubCategory { get; set; } = default!;
		public DbSet<SubCategoryBook> SubCategoryBooks { get; set; } = default!;
		public DbSet<Book> Book { get; set; } = default!;
		public DbSet<Location> Locations { get; set; } = default!;
		public DbSet<Stock> Stocks { get; set; } = default!;
		public DbSet<Employee> Employees { get; set; } = default!;
		public DbSet<ApplicationUser> ApplicationUser { get; set; } = default!;
		public DbSet<BorrowBooks> BorrowBooks { get; set; } = default!;
		public DbSet<Member> Member { get; set; } = default!;
		public DbSet<Language> Language { get; set; } = default!;
		public DbSet<LanguageBook> LanguageBooks { get; set; } = default!;
		public DbSet<Publisher> Publisher { get; set; } = default!;
		public DbSet<BorrowHistory> BorrowHistories { get; set; } = default!;


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// This ensures the default configurations for ASP.NET Identity are included
			base.OnModelCreating(modelBuilder);

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

			modelBuilder.Entity<BorrowHistory>()
			.HasOne(b => b.BorrowingEmployee)
			.WithMany()
			.HasForeignKey(b => b.BorrowingEmployeeId)
			.OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

			modelBuilder.Entity<BorrowHistory>()
			.HasOne(b => b.LendingEmployee)
			.WithMany()
			.HasForeignKey(b => b.LendingEmployeeId)
			.OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

			modelBuilder.Entity<BorrowHistory>()
			.HasOne(b => b.Member)
			.WithMany()
			.HasForeignKey(b => b.MemberId)
			.OnDelete(DeleteBehavior.Restrict); // Similar setup can be applied to other relationships			

			modelBuilder.Entity<BorrowBooks>()
			.HasOne(b => b.Employee)
			.WithMany()
			.HasForeignKey(b => b.EmployeeId)
			.OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete
		}




	}
}
