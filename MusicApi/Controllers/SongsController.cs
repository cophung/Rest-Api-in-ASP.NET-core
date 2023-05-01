using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<SongsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Songs);
            //return BadRequest();
            //return NotFound();
            //return StatusCode(StatusCodes.Status200OK);
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Song song = _dbContext.Songs.Find(id);
            if (song == null)
            {
                return NotFound("No record found against this id");
            }
            return Ok(song);
        }

        // POST api/<SongsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song song)
        {
            await _dbContext.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return Ok("Record Created successfull");
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Song song)
        {
            Song songFound = await _dbContext.Songs.FindAsync(id);
            if (songFound == null)
            {
                return NotFound("No record found against this id");
            }
            songFound.Title = song.Title;
            songFound.Language = song.Language;
            await _dbContext.SaveChangesAsync();
            return Ok("Record Updated successfull");
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Song song = await _dbContext.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found against this id");
            }
            _dbContext.Songs.Remove(song);
            await _dbContext.SaveChangesAsync();
            return Ok("Record Deleted successfull");
        }
    }
}
