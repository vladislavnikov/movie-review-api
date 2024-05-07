using Microsoft.AspNetCore.Mvc.Formatters;

namespace movie_review_api.Data.Models
{
    public class Actor
    {
        public Actor()
        {
            MovieActors = new List<MovieActor>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
