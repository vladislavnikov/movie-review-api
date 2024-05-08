using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using movie_review_api.Contracts;
using movie_review_api.Data;
using movie_review_api.Data.Models;

namespace movie_review_api.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext context;
        public MovieRepository(DataContext _context)
        {
            context = _context;
        }

        public Task CreateMovie(int directorId, int genreId, Movie movie)
        {
            var director = context.Directors.FirstOrDefault(d => d.Id == directorId);
            var genre = context.Genres.FirstOrDefault(g => g.Id == genreId);

            var movieGenre = new MovieGenre()
            {
                Genre = genre,
                Movie = movie,
            };

            context.Add(movieGenre);

            movie.DirectorId = directorId;
            context.Add(movie);

            Save();

            return Task.CompletedTask;
        }

        public Task DeleteMovie(int movieId)
        {
            var movieToDelete = GetMovie(movieId);
            context.Remove(movieToDelete);

            var movieGenresToRemove = context.MovieGenres.Where(mg => mg.MovieId == movieId);
            context.MovieGenres.RemoveRange(movieGenresToRemove);

            Save();
            return Task.CompletedTask;
        }

        public Movie GetMovie(int id)
        {
            return context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public ICollection<Movie> GetMovies()
        {
            return context.Movies.ToList();
        }

        public bool MovieExistsById(int id)
        {
            var movie = context.Movies.Find(id);
            return movie != null ? true : false;
        }

        public bool MovieExistsByTitle(string title)
        {
            var movie = context.Movies.FirstOrDefault(m => m.Title == title);
            return movie != null ? true : false; 
        }

        public Task Save()
        {
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateMovie(int movieId, int directorId, int genreId, Movie movie)
        {
            var movieToUpdate = GetMovie(movieId);

            movieToUpdate.Title = movie.Title;
            movieToUpdate.Description = movie.Description;
            movieToUpdate.DirectorId = directorId;

            Save();
            return Task.CompletedTask;
        }
    }
}
