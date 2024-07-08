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

        public DbSet<libAPI.Models.Category> Categories { get; set; } = default!;
        public DbSet<libAPI.Models.Book> Books { get; set; } = default!;
        public DbSet<libAPI.Models.Language> Languages { get; set; } = default!;
        public DbSet<libAPI.Models.Location> Locations { get; set; } = default!;
        public DbSet<libAPI.Models.SubCategory> SubCategories { get; set; } = default!;
        public DbSet<libAPI.Models.Author> Authors { get; set; } = default!;
        public DbSet<libAPI.Models.Publisher> Publishers { get; set; } = default!;
    }
}
