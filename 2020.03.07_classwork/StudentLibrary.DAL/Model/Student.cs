using System;
using System.Collections.Generic;

namespace StudentLibrary.DAL.Model
{
    public class Student
    {
        public virtual int Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        public virtual DateTime EntranceDate { get; set; }

        public virtual string Email { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual List<Book> Books { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}