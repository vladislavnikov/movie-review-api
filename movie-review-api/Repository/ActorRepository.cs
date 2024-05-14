using Microsoft.AspNetCore.Mvc.ApplicationModels;
using movie_review_api.Contracts;
using movie_review_api.Data;
using movie_review_api.Data.Models;

namespace movie_review_api.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly DataContext context;
        public ActorRepository(DataContext context)
        {
            this.context = context;
        }
        public bool ActorExistsById(int actorId)
        {
            var actor = context.Actors.Where(a => a.Id == actorId);
            return actor != null;
        }

        public bool ActorExistsByName(string actorName)
        {
            return context.Actors
                          .Any(a => a.FirstName + " " + a.LastName == actorName);
        }


        public Task CreateActor(Actor actor)
        {
            context.Actors.Add(actor);
            return Save();
        }

        public Task DeleteActor(int actorId)
        {
            var actor = GetActor(actorId);
            context.Actors.Remove(actor);
            return Save();
        }

        public Actor GetActor(int id)
        {
            return context.Actors.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<Actor> GetActors()
        {
            return context.Actors.ToList();
        }

        public ICollection<Actor> GetActorsByMovie(int movieId)
        {
            return context.MovieActors.Where(a => a.MovieId == movieId)
                .Select(a => a.Actor).ToList();
        }

        public Task Save()
        {
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateActor(int actorId, Actor actor)
        {
            var actorToUpdate = GetActor(actorId);

            actorToUpdate.FirstName = actor.FirstName;
            actorToUpdate.LastName = actor.LastName;

            return Save();
        }
    }
}
