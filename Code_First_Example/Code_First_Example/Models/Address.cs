using System;
using System.Collections.Generic;
using System.Text;

namespace Code_First_Example.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int Zip { get; set; }
    }
}
