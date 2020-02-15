using Microsoft.EntityFrameworkCore;

namespace _2020._02._15_Fluent_API.Models
{
    public class HrDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<JobHistory> JobHistories { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobGrade> JobGrades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
              => optionsBuilder
                //.UseLazyLoadingProxies()
                .UseSqlServer(@"Database=HrDatabase;Trusted_Connection=True;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
                .HasMany<Country>(region => region.Countries)
                .WithOne(country => country.Region);

            modelBuilder.Entity<Country>()
                .HasMany<Location>(country => country.Locations)
                .WithOne(region => region.Country);

            modelBuilder.Entity<Location>()
                .HasMany<Department>(location => location.Departments)
                .WithOne(department => department.Location);

            modelBuilder.Entity<Department>()
                .HasMany<JobHistory>(department => department.JobHistories)
                .WithOne(jobhistory => jobhistory.Department);

            modelBuilder.Entity<Job>()
                .HasMany<JobHistory>(job => job.JobHistories)
                .WithOne(jobhistory => jobhistory.Job);


            modelBuilder.Entity<Employee>()
                .HasMany<JobHistory>(job => job.JobHistories)
                .WithOne(jobhistory => jobhistory.Employee);

            modelBuilder.Entity<Department>()
                .HasMany<Employee>(department => department.Employees)
                .WithOne(employee => employee.Department);

            modelBuilder.Entity<JobHistory>()
                .HasKey(jh => new { jh.EmployeeId, jh.StartDate });

            modelBuilder.Entity<JobGrade>()
                .HasKey(jg => jg.GradeLevel);
        }
    }
}