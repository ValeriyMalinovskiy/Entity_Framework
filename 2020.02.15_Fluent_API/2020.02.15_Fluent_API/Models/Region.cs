using System;
using System.Collections.Generic;
using System.Text;

namespace _2020._02._15_Fluent_API.Models
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}
