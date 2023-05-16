using MusicApi.Data;
using MusicApi.Models;
using System.Collections.Generic;
using System.Linq;

// Implement Repository Pattern in Web Api

namespace MusicApi.Services
{
    public class ArtistRepository : IArtist
    {
        private ApiDbContext _dbContext;
        public ArtistRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddArtist(Artist artist)
        {
            _dbContext.Artists.Add(artist);
            _dbContext.SaveChanges(true);
        }

        public void DeleteArtist(int id)
        {
            var artist = _dbContext.Artists.Find(id);
            _dbContext.Artists.Remove(artist);
            _dbContext.SaveChanges(true);
        }

        public Artist GetArtist(int id)
        {
            var artist = _dbContext.Artists.SingleOrDefault(x => x.Id == id);
            return artist;
        }

        public IEnumerable<Artist> GetArtists()
        {
            return _dbContext.Artists;
        }

        public void UpdateArtist(Artist artist)
        {
            _dbContext.Artists.Update(artist);
            _dbContext.SaveChanges(true);
        }
    }
}
