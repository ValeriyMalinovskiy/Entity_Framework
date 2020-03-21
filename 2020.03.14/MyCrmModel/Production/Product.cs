using MyCrmModel.Sales;
using System.Collections.Generic;

namespace MyCrmModel.Production
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int ModelYear { get; set; }

        public decimal ListPrice { get; set; }

        public virtual List<Stock> Stocks { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }

    }
}