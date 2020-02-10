﻿using System.Collections.Generic;

namespace Code_First_Example.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
