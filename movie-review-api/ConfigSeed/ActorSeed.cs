using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_review_api.Data.Models;
using System.Net;

namespace movie_review_api.ConfigSeed
{
    public class ActorSeed : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasData(CreateActors());
        }

        private List<Actor> CreateActors()
        {
            return new List<Actor>()
            {
                 new Actor { Id = 1, FirstName = "Cillian", LastName="Murphy"},
                new Actor { Id = 2, FirstName = "Tom", LastName="Hanks"},
                new Actor { Id = 3, FirstName = "Meryl", LastName="Streep"},
                new Actor { Id = 4, FirstName = "Leonardo", LastName="DiCaprio"},
                new Actor { Id = 5, FirstName = "Jennifer", LastName="Lawrence"},
                new Actor { Id = 6, FirstName = "Denzel", LastName="Washington"},
                new Actor { Id = 7, FirstName = "Angelina", LastName="Jolie"},

             };

        }
    }
}
