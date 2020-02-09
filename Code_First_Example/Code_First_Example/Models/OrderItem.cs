﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Code_First_Example.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
