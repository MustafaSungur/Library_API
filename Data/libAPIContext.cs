using Microsoft.EntityFrameworkCore;
using libAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace libAPI.Data
{
    public class libAPIContext : DbContext
    {
        public libAPIContext(DbContextOptions<libAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<Language> Languages { get; set; } = default!;
        public DbSet<Location> Locations { get; set; } = default!;
        public DbSet<SubCategory> SubCategories { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Publisher> Publishers { get; set; } = default!;
        public DbSet<AuthorBook> AuthorBooks { get; set; } = default!;
        public DbSet<LanguageBook> LanguageBooks { get; set; } = default!;
        public DbSet<SubCategoryBook> SubCategoryBooks { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
		}
    }
}
