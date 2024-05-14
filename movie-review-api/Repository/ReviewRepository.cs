using movie_review_api.Contracts;
using movie_review_api.Data;
using movie_review_api.Data.Models;
using movie_review_api.DTOs.Review;

namespace movie_review_api.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext context;
        public ReviewRepository(DataContext _context)
        {
            this.context = _context;
        }

        public Task CreateReview(Review review)
        {
            context.Reviews.Add(review);
            return Save();
        }

        public Task DeleteReview(int id)
        {
            var review = GetReview(id);
            context.Remove(review);
            return Save();
        }

        public Review GetReview(int id)
        {
            return context.Reviews.FirstOrDefault(r => r.Id == id);
        }

        public ICollection<Review> GetReviews()
        {
            return context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsByMovie(int movieId)
        {
            return context.Reviews.Where(r => r.MovieId == movieId).ToList();
        }

        public bool ReviewExists(ReviewCreateDto reviewModel)
        {
           var review = context.Reviews.Where(r => r.Grade == reviewModel.Grade &&
                                              r.Description == reviewModel.Description &&
                                              r.MovieId == reviewModel.MovieId);

            return review != null;
        }

        public bool ReviewExistsById(int id)
        {
            var review = context.Reviews.FirstOrDefault(r => r.Id == id);
            return review != null;
        }

        public Task Save()
        {
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateReview(int id, Review review)
        {
            var reviewToUpdate = GetReview(id);

            reviewToUpdate.Grade = review.Grade;
            reviewToUpdate.Description = review.Description;
            reviewToUpdate.MovieId = review.MovieId;

            return Save();
        }
    }
}
