using movie_review_api.Data.Models;

namespace movie_review_api.Contracts
{
    public interface IActorRepository
    {
        ICollection<Actor> GetActors();

        Actor GetActor(int id);

        ICollection<Actor> GetActorsByMovie(int movieId);

        bool ActorExistsById(int actorId);

        bool ActorExistsByName(string actorName);

        Task CreateActor(Actor actor);

        Task UpdateActor(int actorId, Actor actor);

        Task  DeleteActor(int actorId);

        Task Save();
    }
}
