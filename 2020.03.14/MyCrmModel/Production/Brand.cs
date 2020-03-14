using System.Collections.Generic;

namespace MyCrmModel.Production
{
    internal class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
