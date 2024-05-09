using movie_review_api.Data.Models;

namespace movie_review_api.Contracts
{
    public interface IDirectorRepository
    {
        ICollection<Director> GetDirectors();

        Director GetDirector(int id);

        bool DirectorExistsById(int id);
        bool DirectorExistsByName(string name);

        Task CreateDirector(Director director);

        Task UpdateDirector(int directorId, Director director);

        Task DeleteDirector(int directorId);
        Task Save();
    }
}
