namespace movie_review_api.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            Reviews = new List<Review>();
            MovieGenres = new List<MovieGenre>();
            MovieActors = new List<MovieActor>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int DurationMins { get; set; }

        public int ReleaseYear { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
