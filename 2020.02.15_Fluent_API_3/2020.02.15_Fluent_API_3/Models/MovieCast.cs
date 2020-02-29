namespace _2020._02._15_Fluent_API_3.Models
{
    public class MovieCast
    {
        public int ActorId { get; set; }

        public int MovieId { get; set; }

        public string Role { get; set; }

        public Actor Actor { get; set; }

        public Movie Movie { get; set; }
    }
}
