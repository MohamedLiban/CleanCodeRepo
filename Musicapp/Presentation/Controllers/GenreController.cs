using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure;
using Application.Commands.GenreNamespace;
using System;
using System.Linq;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly FakeDatabase _database;

        public GenreController(FakeDatabase database)
        {
            _database = database;
        }

        
        [HttpPost]
        public IActionResult AddGenre([FromBody] AddGenreCommand command)
        {
            try
            {
                command.Execute(_database);
                return Ok("Genre added successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet]
        public IActionResult GetAllGenres()
        {
            if (!_database.Genres.Any())
                return Ok("No genres available.");

            return Ok(_database.Genres);
        }

        
        [HttpPut("{id:guid}")]
        public IActionResult UpdateGenre(Guid id, [FromBody] Genre updatedGenre)
        {
            if (updatedGenre == null || id != updatedGenre.Id)
            {
                return BadRequest("Invalid genre data.");
            }

            var existingGenre = _database.Genres.FirstOrDefault(g => g.Id == id);
            if (existingGenre == null)
            {
                return NotFound($"Genre with ID {id} not found.");
            }

            existingGenre.Name = updatedGenre.Name;
            return NoContent();
        }

        
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteGenre(Guid id)
        {
            var genre = _database.Genres.FirstOrDefault(g => g.Id == id);
            if (genre == null)
            {
                return NotFound($"Genre with ID {id} not found.");
            }

            _database.Genres.Remove(genre);
            return NoContent();
        }
    }
}
