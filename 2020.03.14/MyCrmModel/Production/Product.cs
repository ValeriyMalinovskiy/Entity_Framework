using System;
using System.Collections.Generic;
using System.Text;
using MyCrmModel.Sales;

namespace MyCrmModel.Production
{
    class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int ModelYear { get; set; }

        public decimal ListPrice { get; set; }

        public ICollection<Stock> Stocks { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
