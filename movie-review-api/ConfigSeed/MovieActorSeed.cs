using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_review_api.Data.Models;

namespace movie_review_api.ConfigSeed
{
    public class MovieActorSeed : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasData(CreateMovieActors());
        }

        private List<MovieActor> CreateMovieActors()
        {
            return new List<MovieActor>() {
                new MovieActor { MovieId = 1, ActorId = 1 },
                new MovieActor { MovieId = 1, ActorId = 5 },
                new MovieActor { MovieId = 1, ActorId = 7 },
                new MovieActor { MovieId = 2, ActorId = 4 },
                new MovieActor { MovieId = 2, ActorId = 7 },
                new MovieActor { MovieId = 3, ActorId = 1 },
                new MovieActor { MovieId = 3, ActorId = 7 }

            };
        }
    }
}
