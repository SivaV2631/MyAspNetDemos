using JobPortal1.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal1.Data
{
    public class ApplicationDbContext
        : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Education> Educations { get; set; }
        public DbSet<Employee> Employees { get; set; }


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
        public DbSet<JobNature> JobNatures { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }
        public DbSet<JobRequirementDetail> JobRequirementsDetails { get; set; }
    }
}
