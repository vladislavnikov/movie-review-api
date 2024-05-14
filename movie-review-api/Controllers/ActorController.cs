using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movie_review_api.Contracts;
using movie_review_api.Data.Models;
using movie_review_api.DTOs.Actor;

namespace movie_review_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : Controller
    {
        readonly private IMapper mapper;
        readonly private IActorRepository actorRepository;

        public ActorController(IMapper _mapper, IActorRepository _actorRepository)
        {
            this.mapper = _mapper;
            this.actorRepository = _actorRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Actor>))]
        public async Task<IActionResult> GetActors()
        {
            var actors = mapper.Map<List<ActorDto>>(actorRepository.GetActors());

            if (actors == null)
            {
                return BadRequest("No actors!");
            }

            return Ok(actors);
        }

        [HttpGet("{actorId}")]
        [ProducesResponseType(200, Type = typeof(Actor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetActor(int actorId)
        {
            var isFound = actorRepository.ActorExistsById(actorId);

            if (!isFound)
            {
                return NotFound();
            }

            var actor = mapper.Map<ActorDto>(actorRepository.GetActor(actorId));

            if (actor == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(actor);
        }

        [HttpGet("actors/{movieId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Actor>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetActorsByMovie(int movieId)
        {
            var actors = mapper.Map<List<ActorDto>>(actorRepository.GetActorsByMovie(movieId));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            return Ok(actors);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateActor([FromBody] ActorCreateDto actorModel)
        {
            if (actorModel == null)
            {
                return BadRequest(ModelState);
            }

            if (actorRepository.ActorExistsByName(actorModel.FirstName + " " + actorModel.LastName))
            {
                ModelState.AddModelError("", "Actor already exists");
                return StatusCode(422, ModelState);
            }

            var actorMap = mapper.Map<Actor>(actorModel);

            await actorRepository.CreateActor(actorMap);

            return Ok();
        }

        [HttpPut("{actorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateActor(int actorId, [FromBody] ActorUpdateDto updatedActor)
        {
            if (updatedActor == null)
            {
                return BadRequest(ModelState);
            }

            if (actorId != updatedActor.Id)
            {
                return BadRequest("IDs are not the same");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var actorMap = mapper.Map<Actor>(updatedActor);

            await actorRepository.UpdateActor(actorId, actorMap);

            return Ok();
        }

        [HttpDelete("{actorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> DeleteActor(int actorId)
        {
            if (!actorRepository.ActorExistsById(actorId))
            {
                return NotFound();
            }

            await actorRepository.DeleteActor(actorId);

            return Ok();
        }

    }
}
