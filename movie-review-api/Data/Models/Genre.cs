namespace movie_review_api.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            MovieGenres = new List<MovieGenre>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
