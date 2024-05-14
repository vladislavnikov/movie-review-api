using movie_review_api.Contracts;
using movie_review_api.Data;
using movie_review_api.Data.Models;

namespace movie_review_api.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext context;
        public GenreRepository(DataContext _context)
        {
            this.context = _context;
        }
        public Task CreateGenre(Genre genre)
        {
            context.Add(genre);
            return Save();
        }

        public Task DeleteGenre(int genreId)
        {
            var genre = GetGenre(genreId);
            context.Remove(genre);
            return Save();
        }

        public bool GenreExistsById(int id)
        {
            var genre = context.Genres.Where(g => g.Id == id);
            return genre != null;
        }

        public bool GenreExistsByName(string name)
        {
            var genre = context.Genres.Where(g => g.Name == name);
            return genre != null;
        }

        public Genre GetGenre(int id)
        {
            return context.Genres.FirstOrDefault(g => g.Id == id);
        }

        public ICollection<Genre> GetGenres()
        {
            return context.Genres.ToList();
        }

        public ICollection<Movie> GetMoviesByGenre(int Id)
        {
            return context.MovieGenres.Where(g => g.GenreId == Id).Select(g => g.Movie).ToList();
        }

        public Task Save()
        {
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateGenre(int genreId, Genre genre)
        {
            var genreToUpdate = GetGenre(genreId);

            genreToUpdate.Name = genre.Name;

            return Save();
        }
    }
}
