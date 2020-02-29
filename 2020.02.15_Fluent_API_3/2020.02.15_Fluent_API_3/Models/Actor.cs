using System.Collections.Generic;

namespace _2020._02._15_Fluent_API_3.Models
{
    public class Actor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
