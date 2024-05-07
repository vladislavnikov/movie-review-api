using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_review_api.Data.Models;

namespace movie_review_api.ConfigSeed
{
    public class MovieSeed : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(CreateMovies());
        }

        private List<Movie> CreateMovies()
        {
            return new List<Movie>()
            {
            new Movie() {Id= 1, Title = "Inception", Description="A mind-bending heist movie", DurationMins = 148, ReleaseYear = 2010, DirectorId = 1,},
            new Movie() {Id= 2, Title = "Catch Me If You Can", Description="A cat-and-mouse game between a con artist and an FBI agent", DurationMins = 141, ReleaseYear = 2002, DirectorId = 2},
            new Movie() {Id= 3, Title = "The Dark Knight", Description="The Joker wreaks havoc on Gotham City", DurationMins = 152, ReleaseYear = 2008, DirectorId = 1},

            };
        }
    }
}
