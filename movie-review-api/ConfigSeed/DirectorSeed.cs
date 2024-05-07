using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_review_api.Data.Models;

namespace movie_review_api.ConfigSeed
{
    public class DirectorSeed : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasData(CreateDirectors());
        }

        private List<Director> CreateDirectors()
        {
            return new List<Director>()
            {
                new Director() {Id= 1, FirstName= "Christopher", LastName= "Nolan"},
                new Director() {Id= 2, FirstName= "Steven", LastName= "Spielberg"},
                new Director() {Id= 3, FirstName= "Quentin", LastName= "Tarantino"}
             };
        }

    }
}

