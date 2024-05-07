using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_review_api.Data.Models;

namespace movie_review_api.ConfigSeed
{
    public class MovieGenreSeed : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasData(CreateMovieGenres());
        }

        private List<MovieGenre> CreateMovieGenres()
        {
            return new List<MovieGenre>()
            {
             new MovieGenre { MovieId = 1, GenreId = 6 },
             new MovieGenre { MovieId = 2, GenreId = 5 },
             new MovieGenre { MovieId = 3, GenreId = 3 }
            };
        }
    }
}
