using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrmModel.Production
{
    class Stock
    {
        public int StoreId { get; set; }
        
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
