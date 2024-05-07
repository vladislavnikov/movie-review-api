namespace movie_review_api.Data.Models
{
    public class Director
    {
        public Director()
        {
            Movies = new List<Movie>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
