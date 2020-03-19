using MyCrmModel.Production;
using System.Collections.Generic;

namespace MyCrmModel.Sales
{
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
