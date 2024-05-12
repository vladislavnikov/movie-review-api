namespace movie_review_api.DTOs.Review
{
    public class ReviewCreateDto
    {
        public string Grade { get; set; }

        public string Description { get; set; }

        public int MovieId { get; set; }
    }
}
