using movie_review_api.Data.Models;
using movie_review_api.DTOs.Review;

namespace movie_review_api.Contracts
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();

        Review GetReview(int id);

        ICollection<Review> GetReviewsByMovie(int movieId);

        bool ReviewExistsById(int id);
        bool ReviewExists(ReviewCreateDto reviewModel);

        Task CreateReview(Review review);
        Task UpdateReview(int id, Review review);

        Task DeleteReview(int id);

        Task Save();
    }
}
