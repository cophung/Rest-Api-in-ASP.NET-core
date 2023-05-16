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
    public class SongsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Songs);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetSongs(int? pageNumber, int? pageSize)
        {
            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            var songs = await (from song in _dbContext.Songs
                               orderby song.UploadeDate descending
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                                   Duration = song.Duration,
                                   UploadeDate = song.UploadeDate,
                                   IsFeatured = song.IsFeatured,
                                   AlbumId = song.AlbumId,
                                   ArtistId = song.ArtistId
                               }).ToListAsync();
            return Ok(songs.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> GetSong(int id)
        {
            var artist = await _dbContext.Songs.Where(x => x.Id == id).ToListAsync();
            return Ok(artist);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> SearchSongs(string query)
        {
            var songs = await (from song in _dbContext.Songs
                               where song.Title.StartsWith(query)
                               orderby song.UploadeDate descending
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                                   Duration = song.Duration,
                                   UploadeDate = song.UploadeDate,
                                   IsFeatured = song.IsFeatured,
                                   AlbumId = song.AlbumId,
                                   ArtistId = song.ArtistId
                               }).ToListAsync();
            return Ok(songs);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Song song)
        {
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
