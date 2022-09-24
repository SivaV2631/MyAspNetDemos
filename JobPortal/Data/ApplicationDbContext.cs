using JobPortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data
{
    public class ApplicationDbContext
        :IdentityDbContext              //DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CurrentJobStatus> CurrentJobStatuses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EventTable> EventTables { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApply> JobApplies { get; set; }
        public DbSet<JobApplyStatus> JobApplyStatuses { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobStatus> JobStatuses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PostJob> PostJobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserTable> UserTables { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<WorkExperience> WorkExperiences { get; set; }






    }
}
