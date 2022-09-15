using Microsoft.EntityFrameworkCore;
using Bootstrap2.Models;

namespace Bootstrap2.Data
{
    public class ApplicationDbContext
        : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
