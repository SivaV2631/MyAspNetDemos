using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant1.Models;

namespace Restaurant1.Data
{
    public class ApplicationDbContext
        : IdentityDbContext                                       //DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Order> Orderrs { get; set; }

        public DbSet<Order> Orderrrs { get; set; }


        public DbSet<Payment> Payments { get; set; }

        public DbSet<Restaurant1.Models.Orderr> Orderr { get; set; }

        public DbSet<Restaurant1.Models.Orderrr> Orderrr { get; set; }


    }
}
