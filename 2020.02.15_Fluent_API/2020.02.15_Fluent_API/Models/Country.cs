using System;
using System.Collections.Generic;
using System.Text;

namespace _2020._02._15_Fluent_API.Models
{
    public class Country
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Region Region { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
