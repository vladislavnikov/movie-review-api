using movie_review_api.Data.Models;

namespace movie_review_api.Contracts
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();

        Movie GetMovie(int id);

        bool MovieExistsById(int id);
        bool MovieExistsByTitle(string title);

        Task CreateMovie(int directorId, int genreId, Movie movie);

        Task UpdateMovie(int movieId, int directorId, int genreId, Movie movie);

        Task DeleteMovie(int movieId);

        Task Save();
    }


}
