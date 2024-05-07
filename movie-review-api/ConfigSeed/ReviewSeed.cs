using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_review_api.Data.Models;

namespace movie_review_api.ConfigSeed
{
    public class ReviewSeed : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(CreateReviews());
        }

        private List<Review> CreateReviews()
        {
            return new List<Review>
            {
                new Review { Id = 1, Grade = "A", Description = "Excellent movie!", MovieId = 1 },
                new Review { Id = 2, Grade = "B", Description = "Good movie, but could have been better.", MovieId = 2 },
                new Review { Id = 3, Grade = "A+", Description = "One of the best movies I've ever seen.", MovieId = 3 }
            };
        }

    }
}
