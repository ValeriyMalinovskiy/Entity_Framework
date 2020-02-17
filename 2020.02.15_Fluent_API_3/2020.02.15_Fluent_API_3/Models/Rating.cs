namespace _2020._02._15_Fluent_API_3.Models
{
    public class Rating
    {
        public int MovieId { get; set; }

        public int ReviewerId { get; set; }

        public int ReviewerStars { get; set; }

        public int NumberOfRatings { get; set; }

        public Movie Movie { get; set; }

        public Reviewer Reviewer { get; set; }
    }
}
