using movie_review_api.Contracts;
using movie_review_api.Data;
using movie_review_api.Data.Models;
using System.Runtime.CompilerServices;

namespace movie_review_api.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly DataContext context;
        public DirectorRepository(DataContext _context)
        {
            this.context = _context;
        }

        public Task CreateDirector(Director director)
        {
            context.Add(director);
            Save();
            return Task.CompletedTask;
        }

        public Task DeleteDirector(int directorId)
        {
            var director = GetDirector(directorId);
            context.Directors.Remove(director);
            Save();
            return Task.CompletedTask;
        }

        public bool DirectorExistsById(int id)
        {
            var director = context.Directors.FirstOrDefault(d => d.Id == id);
            return director != null;
        }

        public bool DirectorExistsByName(string name)
        {
            var director = context.Directors.FirstOrDefault(d => d.FirstName + " " + d.LastName == name);
            return director != null;
        }

        public Director GetDirector(int id)
        {
            return context.Directors.FirstOrDefault(d => d.Id == id);
        }

        public ICollection<Director> GetDirectors()
        {
            return context.Directors.ToList();
        }

        public Task Save()
        {
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateDirector(int directorId, Director director)
        {
            var directorToUpdate = GetDirector(directorId);

            directorToUpdate.FirstName = director.FirstName;
            directorToUpdate.LastName = director.LastName;

            Save();
            return Task.CompletedTask;
        }
    }
}
