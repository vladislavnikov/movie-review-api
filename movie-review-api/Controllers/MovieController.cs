using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movie_review_api.Contracts;
using movie_review_api.Data.Models;
using movie_review_api.DTOs.Movie;
using movie_review_api.Repository;

namespace movie_review_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMovieRepository movieRepository;
        public MovieController(IMapper _mapper, IMovieRepository _movieRepository)
        {
            this.mapper = _mapper;
            this.movieRepository = _movieRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Movie>))]
        public async Task<IActionResult> GetMovies()
        {
            var movies = mapper.Map<List<MovieDto>>(movieRepository.GetMovies());

            if (movies == null)
            {
                return BadRequest("No movies!");
            }

            return Ok(movies);
        }

        [HttpGet("{movieId}")]
        [ProducesResponseType(200, Type = typeof(Movie))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSchool(int movieId)
        {
            var isFound = movieRepository.MovieExistsById(movieId);

            if (!isFound)
            {
                return NotFound();
            }

            var movie = mapper.Map<MovieDto>(movieRepository.GetMovie(movieId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMovie([FromQuery] int directorId, [FromQuery] int genreId, [FromBody] MovieCreateDto movieModel)
        {
            if (movieModel == null)
            {
                return BadRequest(ModelState);
            }

            if (movieRepository.MovieExistsByTitle(movieModel.Title))
            {
                ModelState.AddModelError("", "Movie already exists");
                return StatusCode(422, ModelState);
            }

            var movieMap = mapper.Map<Movie>(movieModel);

            movieRepository.CreateMovie(directorId, genreId, movieMap);

            return Ok();
        }

        [HttpPut("{movieId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateMovie(int movieId, [FromQuery] int genreId,
            [FromBody] MovieUpdateDto updatedMovie)
        {
            if (updatedMovie == null)
            {
                return BadRequest(ModelState);
            }

            if (movieId != updatedMovie.Id)
            {
                return BadRequest("IDs are not the same");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieMap = mapper.Map<Movie>(updatedMovie);

            movieRepository.UpdateMovie(movieId, movieMap.DirectorId, genreId, movieMap);

            return NoContent();
        }

        [HttpDelete("{movieId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            if (!movieRepository.MovieExistsById(movieId))
            {
                return NotFound();
            }

            movieRepository.DeleteMovie(movieId);
            return NoContent();
        }
    }
}
