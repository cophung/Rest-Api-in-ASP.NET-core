using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public AlbumsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Albums);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAlbums()
        {
            var albums = await (from album in _dbContext.Albums
                                select new
                                {
                                    Id = album.Id,
                                    Name = album.Name,
                                    Gender = album.ImageUrl
                                }).ToListAsync();
            return Ok(albums);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> GetAlbum(int id)
        {
            var artist = await _dbContext.Albums.Where(x => x.Id == id).Include(a => a.Songs).ToListAsync();
            return Ok(artist);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Album album)
        {
            await _dbContext.Albums.AddAsync(album);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
