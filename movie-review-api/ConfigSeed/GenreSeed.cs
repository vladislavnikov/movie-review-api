using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_review_api.Data.Models;

namespace movie_review_api.ConfigSeed
{
    public class GenreSeed : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(CreateGenres());
        }

        private List<Genre> CreateGenres()
        {
          return new List<Genre>()
          { 
            new Genre() {Id=1, Name = "Comedy"},
            new Genre() {Id=2, Name = "Horror"},
            new Genre() {Id=3, Name = "Action"},
            new Genre() {Id=4, Name = "Cartoon"},
            new Genre() {Id=5, Name = "Drama"},
            new Genre() {Id=6, Name = "Fantasy"},
            new Genre() {Id=7, Name = "Mystery"},
            new Genre() {Id=8, Name = "Documentary"},
            new Genre() {Id=9, Name = "Adventure"},
            new Genre() {Id=10, Name = "Musical"}
          };
        }
    }
}
