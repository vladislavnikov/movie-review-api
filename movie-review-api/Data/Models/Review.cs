namespace movie_review_api.Data.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Grade { get; set; }

        public string Description { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
