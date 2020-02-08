﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Code_First_Example.Models
{
    class Order
    {
        public int Id{ get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int ItemsTotal { get; set; }

        public string Phone { get; set; }

        public string DeliveryStreet { get; set; }

        public string DeliveryCity { get; set; }

        public int DeliveryZip { get; set; }
    }
}
