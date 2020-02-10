using System.Collections.Generic;

namespace Code_First_Example.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
