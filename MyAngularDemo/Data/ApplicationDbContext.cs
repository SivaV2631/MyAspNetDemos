using Microsoft.EntityFrameworkCore;
using MyAngularDemo.Models;

namespace MyAngularDemo.Data
{
    public class ApplicationDbContext
        : DbContext                       //IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
