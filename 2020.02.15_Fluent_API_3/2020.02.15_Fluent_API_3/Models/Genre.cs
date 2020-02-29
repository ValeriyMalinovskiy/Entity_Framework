using System.Collections.Generic;

namespace _2020._02._15_Fluent_API_3.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
