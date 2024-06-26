﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movie_review_api.Common;
using movie_review_api.Contracts;
using movie_review_api.Data.Models;
using movie_review_api.DTOs.Director;

namespace movie_review_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : Controller
    {
        private readonly IMapper mapper;
        private readonly IDirectorRepository directorRepository;

        public DirectorController(IMapper _mapper, IDirectorRepository _directorRepository)
        {
            this.mapper = _mapper;
            this.directorRepository = _directorRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Director>))]
        public async Task<IActionResult> GetDirectors()
        {
            var directors = mapper.Map<List<DirectorDto>>(directorRepository.GetDirectors());

            if (directors == null)
            {
                return BadRequest(Messages.NoDirectors);
            }

            return Ok(directors);
        }

        [HttpGet("{directorId}")]
        [ProducesResponseType(200, Type = typeof(Director))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetDirector(int directorId)
        {
            var isFound = directorRepository.DirectorExistsById(directorId);

            if (!isFound)
            {
                return NotFound(Messages.DirectorNotFound);
            }

            var director = mapper.Map<DirectorDto>(directorRepository.GetDirector(directorId));

            if (director == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(director);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateDirector([FromBody] DirectorCreateDto directorModel)
        {
            if (directorModel == null)
            {
                return BadRequest(ModelState);
            }

            if (directorRepository.DirectorExistsByName(directorModel.FirstName + " " + directorModel.LastName))
            {
                ModelState.AddModelError("", Messages.DirectorExists);
                return StatusCode(422, ModelState);
            }

            var directorMap = mapper.Map<Director>(directorModel);

           await directorRepository.CreateDirector(directorMap);

            return Ok();
        }

        [HttpPut("{directorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateDirector(int directorId, [FromBody] DirectorUpdateDto updatedDirector)
        {
            if (updatedDirector == null)
            {
                return BadRequest(ModelState);
            }

            if (directorId != updatedDirector.Id)
            {
                return BadRequest(Messages.NoSameIds);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var directorMap = mapper.Map<Director>(updatedDirector);

           await directorRepository.UpdateDirector(directorId, directorMap);

            return Ok();
        }

        [HttpDelete("{directorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteDirector(int directorId)
        {
            if (!directorRepository.DirectorExistsById(directorId))
            {
                return NotFound(Messages.DirectorExists);
            }

            await directorRepository.DeleteDirector(directorId);

            return Ok();
        }
    }
}
