using System;
using System.Collections.Generic;
using System.Text;

namespace StudentLibrary.DAL.Model
{
    public class Address
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string LocalAddress { get; set; }

        public int PostalCode { get; set; }

        public Student Student { get; set; }
    }
}
