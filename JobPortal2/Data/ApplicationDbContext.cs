using JobPortal2.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal2.Data
{
    public class ApplicationDbContext
        : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        public DbSet<Company> Companies { get; set; }

        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobStatus> JobStatuses { get; set; }

        public DbSet<PostJob> PostJobs { get; set; }

        public DbSet<UserTable> UserTables { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<JobNature> JobNatures { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }


        public DbSet<ApplyJob> ApplyJobs { get; set; }



    }

}
