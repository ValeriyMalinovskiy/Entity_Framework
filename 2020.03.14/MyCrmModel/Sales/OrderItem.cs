using MyCrmModel.Production;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrmModel.Sales
{
    class OrderItem
    {
        public int OrderId { get; set; }
        
        public int ItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal ListPrice { get; set; }

        public decimal Discount { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
