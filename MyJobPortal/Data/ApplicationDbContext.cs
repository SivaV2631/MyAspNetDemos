using Microsoft.EntityFrameworkCore;
using MyJobPortal.Models;

namespace MyJobPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<UserTable> UserTables { get; set; }

        public DbSet<AccountStatus>  AccountStatuses { get; set; }

    }
}
