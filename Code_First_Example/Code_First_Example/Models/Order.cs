using System;
using System.Collections.Generic;

namespace Code_First_Example.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int ItemsTotal { get; set; }

        public string Phone { get; set; }

        public string DeliveryStreet { get; set; }

        public string DeliveryCity { get; set; }

        public int DeliveryZip { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
