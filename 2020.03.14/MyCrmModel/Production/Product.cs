using MyCrmModel.Sales;
using System.Collections.Generic;

namespace MyCrmModel.Production
{
    internal class Product
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
