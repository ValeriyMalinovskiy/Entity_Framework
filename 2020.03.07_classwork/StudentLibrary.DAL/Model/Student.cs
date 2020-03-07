using System;
using System.Collections.Generic;

namespace StudentLibrary.DAL.Model
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime EntranceDate { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public List<Book> Books { get; set; }

        public Address Address { get; set; }
    }
}