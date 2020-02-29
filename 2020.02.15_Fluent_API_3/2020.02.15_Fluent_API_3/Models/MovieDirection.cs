namespace _2020._02._15_Fluent_API_3.Models
{
    public class MovieDirection
    {
        public int DirectorId { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public Director Director { get; set; }
    }
}
