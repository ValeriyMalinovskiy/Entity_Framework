using System.Collections.Generic;

namespace _2020._02._15_Fluent_API_3.Models
{
    public class Reviewer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
