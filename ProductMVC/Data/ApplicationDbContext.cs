using Microsoft.EntityFrameworkCore;
using ProductMVC.Models;

namespace ProductMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        

    }
}



