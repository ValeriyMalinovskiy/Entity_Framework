using System;
using System.Collections.Generic;
using System.Text;

namespace _2020._02._15_Fluent_API.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string StreetAddress { get; set; }

        public Country Country { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
