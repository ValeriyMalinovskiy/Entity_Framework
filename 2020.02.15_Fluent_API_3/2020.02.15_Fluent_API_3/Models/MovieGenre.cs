namespace _2020._02._15_Fluent_API_3.Models
{
    public class MovieGenre
    {
        public int MovieId { get; set; }

        public int GenreId { get; set; }

        public Movie Movie { get; set; }

        public Genre Genre { get; set; }
    }
}
