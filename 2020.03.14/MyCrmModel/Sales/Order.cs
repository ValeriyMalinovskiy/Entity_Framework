
using System;
using System.Collections.Generic;

namespace MyCrmModel.Sales
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string OrderStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int StoreId { get; set; }

        public virtual Store Store { get; set; }

        public int StaffId { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
