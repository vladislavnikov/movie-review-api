using movie_review_api.Data.Models;

namespace movie_review_api.Contracts
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetGenres();

        Genre GetGenre(int id);

        ICollection<Movie> GetMoviesByGenre(int Id);

        bool GenreExistsById(int id);
        bool GenreExistsByName(string name);

        Task CreateGenre(Genre genre);

        Task UpdateGenre(int genreId, Genre genre);

        Task DeleteGenre(int genreId);
        Task Save();
    }
}
