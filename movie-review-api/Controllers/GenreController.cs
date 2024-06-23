using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movie_review_api.Common;
using movie_review_api.Contracts;
using movie_review_api.Data.Models;
using movie_review_api.DTOs.Director;
using movie_review_api.DTOs.Genre;
using movie_review_api.DTOs.Movie;
using movie_review_api.Repository;
using System.IO;

namespace movie_review_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IMapper mapper;
        private readonly IGenreRepository genreRepository;

        public GenreController(IMapper _mapper, IGenreRepository _genreRepository)
        {
            this.mapper = _mapper;
            this.genreRepository = _genreRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Genre>))]
        public async Task<IActionResult> GetGenres()
        {
            var genres = mapper.Map<List<GenreDto>>(genreRepository.GetGenres());

            if (genres == null)
            {
                return BadRequest(Messages.NoGenres);
            }

            return Ok(genres);
        }

        [HttpGet("{genreId}")]
        [ProducesResponseType(200, Type = typeof(Genre))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGenre(int genreId)
        {
            var isFound = genreRepository.GenreExistsById(genreId);

            if (!isFound)
            {
                return NotFound(Messages.GenreNotFound);
            }

            var genre = mapper.Map<GenreDto>(genreRepository.GetGenre(genreId));

            if (genre == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(genre);
        }

        [HttpGet("movie/{genreId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Movie>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {
            var movies = mapper.Map<List<MovieDto>>(genreRepository.GetMoviesByGenre(genreId));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            return Ok(movies);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateGenre([FromBody] GenreCreateDto genreModel)
        {
            if (genreModel == null)
            {
                return BadRequest(ModelState);
            }

            if (genreRepository.GenreExistsByName(genreModel.Name))
            {
                ModelState.AddModelError("", Messages.GenreExists);
                return StatusCode(422, ModelState);
            }

            var genreMap = mapper.Map<Genre>(genreModel);

           await genreRepository.CreateGenre(genreMap);

            return Ok();
        }

        [HttpPut("{genreId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateGenre(int genreId, [FromBody] GenreUpdateDto updatedGenre)
        {
            if (updatedGenre == null)
            {
                return BadRequest(ModelState);
            }

            if (genreId != updatedGenre.Id)
            {
                return BadRequest(Messages.NoSameIds);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var genreMap = mapper.Map<Genre>(updatedGenre);

            await genreRepository.UpdateGenre(genreId, genreMap);

            return Ok();
        }

        [HttpDelete("{genreId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> DeleteGenre(int genreId)
        {
            if (!genreRepository.GenreExistsById(genreId))
            {
                return NotFound(Messages.GenreNotFound);
            }

            await genreRepository.DeleteGenre(genreId);

            return Ok();
        }
    }
}
