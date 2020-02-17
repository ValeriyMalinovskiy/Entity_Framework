using System.Collections.Generic;

namespace _2020._02._15_Fluent_API_3.Models
{
    public class Director
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<MovieDirection> MovieDirections { get; set; }
    }
}
