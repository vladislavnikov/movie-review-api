using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movie_review_api.ConfigSeed;
using movie_review_api.Contracts;
using movie_review_api.Data.Models;
using movie_review_api.DTOs.Genre;
using movie_review_api.DTOs.Review;
using movie_review_api.Repository;

namespace movie_review_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IMapper mapper;
        private readonly IReviewRepository reviewRepository;
        private readonly IMovieRepository movieRepository;
        public ReviewController(IMapper _mapper, IReviewRepository _reviewRepository, IMovieRepository _movireRepository)
        {
            this.mapper = _mapper;
            this.reviewRepository = _reviewRepository;
            this.movieRepository = _movireRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = mapper.Map<List<ReviewDto>>(reviewRepository.GetReviews());

            if (reviews == null)
            {
                return BadRequest("No reviews!");
            }

            return Ok(reviews);
        }

        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetReview(int reviewId)
        {
            var isFount = reviewRepository.ReviewExistsById(reviewId);

            if (!isFount)
            {
                return NotFound();
            }

            var review = mapper.Map<ReviewDto>(reviewRepository.GetReview(reviewId));

            if (review == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(review);
        }

        [HttpGet("movie/{movieId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetReviewsByMovie(int movieId)
        {
            var isFount = movieRepository.MovieExistsById(movieId);

            if (!isFount)
            {
                return NotFound("No movie found!");
            }

            var reviews = mapper.Map<List<ReviewDto>>(reviewRepository.GetReviewsByMovie(movieId));

            if (reviews == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviews);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReview([FromBody] ReviewCreateDto reviewModel)
        {
            if (reviewModel == null)
            {
                return BadRequest(ModelState);
            }

            if (reviewRepository.ReviewExists(reviewModel))
            {
                ModelState.AddModelError("", "Review already exists");
                return StatusCode(422, ModelState);
            }

            var reviewMap = mapper.Map<Review>(reviewModel);

            await reviewRepository.CreateReview(reviewMap);

            return Ok();
        }

        [HttpPut("{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] ReviewUpdateDto updatedReview)
        {
            if (updatedReview == null)
            {
                return BadRequest(ModelState);
            }

            if (reviewId != updatedReview.Id)
            {
                return BadRequest("IDs are not the same");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var reviewMap = mapper.Map<Review>(updatedReview);

            await reviewRepository.UpdateReview(reviewId, reviewMap);

            return Ok();
        }

        [HttpDelete("{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            if (!reviewRepository.ReviewExistsById(reviewId))
            {
                return NotFound();
            }

            await reviewRepository.DeleteReview(reviewId);

            return Ok();
        }

    }
}
