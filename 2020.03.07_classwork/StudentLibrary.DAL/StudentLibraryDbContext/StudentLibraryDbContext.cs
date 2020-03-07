using Microsoft.EntityFrameworkCore;
using StudentLibrary.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentLibrary.DAL.StudentLibraryDbContext
{
    class StudentLibraryDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=StudentLibraryDb;Trusted_Connection=True;");
        }
    }
}
