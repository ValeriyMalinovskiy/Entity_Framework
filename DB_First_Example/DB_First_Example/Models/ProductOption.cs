﻿using System;
using System.Collections.Generic;

namespace DB_First_Example.Models
{
    public partial class ProductOption
    {
        public ProductOption()
        {
            OrderItemOption = new HashSet<OrderItemOption>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Factor { get; set; }
        public bool? IsPizzaOption { get; set; }
        public bool? IsSaladOption { get; set; }

        public virtual ICollection<OrderItemOption> OrderItemOption { get; set; }
    }
}
