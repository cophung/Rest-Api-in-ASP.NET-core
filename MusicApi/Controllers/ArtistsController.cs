using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;
using MusicApi.Services;
using System.Collections.Generic;

// Implement Repository Pattern in Web Api (recommended)

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private IArtist artistRepository;
        public ArtistsController(IArtist _artistRepository)
        {
            artistRepository = _artistRepository;
        }

        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return artistRepository.GetArtists();
        }

        [HttpGet("[action]/{id}")]
        public ActionResult GetArtist(int id)
        {
            var artist = artistRepository.GetArtist(id);
            if (artist == null)
            {
                return NotFound("No record found ...");
            }
            return Ok(artist);
        }

        [HttpPost]
        public IActionResult Post([FromForm] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            artistRepository.AddArtist(artist);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != artist.Id)
            {
                return BadRequest();
            }
            artistRepository.UpdateArtist(artist);
            return Ok("Product updated ...");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            artistRepository.DeleteArtist(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
