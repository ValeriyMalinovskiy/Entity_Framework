using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Code_First_Homework.Models
{
    public class CompanyContext:DbContext
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
        {
            optionsBuilder.UseSqlServer(@"Database=CompanyDB;Trusted_Connection=True;");
        }
    }
}
