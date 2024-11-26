using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicArtistController : ControllerBase
    {
        private readonly FakeDatabase _database;

        public MusicArtistController(FakeDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult GetAllMusicArtists()
        {
            return Ok(_database.MusicArtists);
        }

        [HttpPost]
        public IActionResult AddMusicArtist([FromBody] MusicArtist artist)
        {
            if (artist == null || string.IsNullOrWhiteSpace(artist.Name))
                return BadRequest("Artist data is invalid.");

            artist.Id = Guid.NewGuid();
            _database.MusicArtists.Add(artist);
            return Ok("Music artist added successfully.");
        }
    }
}
