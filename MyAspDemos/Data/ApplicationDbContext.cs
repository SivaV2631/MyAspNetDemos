using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAspDemos.Models;

namespace MyAspDemos.Data
{
    public class ApplicationDbContext
        : IdentityDbContext                       //DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MyAspDemos.Models.Book> Books { get; set; }
        public DbSet<MyAspDemos.Models.Author> Authors { get; set; }
    }
}
