using Microsoft.EntityFrameworkCore;
using StudentLibrary.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLibrary.DAL.StudentLibraryDatabaseContext
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Book tempBook1 = new Book { Id = 1, Author = "Smb", Titile = "Smth", Year = 1998, StudentId = 1 };
            Book tempBook2 = new Book { Id = 2, Author = "Smb2", Titile = "Smth2", Year = 2000, StudentId = 1 };
            Book tempBook3 = new Book { Id = 3, Author = "Smb3", Titile = "Smth2", Year = 2002, StudentId = 1 };
            Book[] tempBooks = { tempBook1, tempBook2, tempBook3 };
            Address tempAddress = new Address { Id = 1, Country = "Ukraine", City = "Kharkiv", LocalAddress = "Borthenko st.5, 25", PostalCode = 61177 };
            modelBuilder.Entity<Book>().HasData(tempBook1);
            modelBuilder.Entity<Book>().HasData(tempBook2);
            modelBuilder.Entity<Book>().HasData(tempBook3);
            modelBuilder.Entity<Address>().HasData(tempAddress);
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                FirstName = "V",
                LastName = "M",
                DateOfBirth = new DateTime(1990, 12, 05),
                EntranceDate = new DateTime(2008, 09, 01),
                Email = "mdfcnvsn@gmail.com",
                PhoneNumber = "0634608651",
                AddressId = 1,
            });
        }
    }
}
