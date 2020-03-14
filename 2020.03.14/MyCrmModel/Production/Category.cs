using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrmModel.Production
{
    class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
