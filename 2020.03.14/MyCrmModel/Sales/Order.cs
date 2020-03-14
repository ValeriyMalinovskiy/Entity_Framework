﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrmModel.Sales
{
    class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string OrderStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int StoreId { get; set; }

        public Store Store { get; set; }

        public int StaffId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
