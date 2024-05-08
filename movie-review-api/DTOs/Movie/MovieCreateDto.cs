namespace movie_review_api.DTOs.Movie
{
    public class MovieCreateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int DurationMins { get; set; }

        public int ReleaseYear { get; set; }
    }
}
