namespace movie_review_api.DTOs.Review
{
    public class ReviewUpdateDto
    {
        public int Id { get; set; }

        public string Grade { get; set; }

        public string Description { get; set; }

        public int MovieId { get; set; }
    }
}
