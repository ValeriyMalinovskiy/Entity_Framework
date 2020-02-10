using System.Collections.Generic;

namespace Code_First_Example.Models
{
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string WebSite { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
