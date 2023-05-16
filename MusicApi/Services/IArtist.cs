using MusicApi.Models;
using System.Collections.Generic;

namespace MusicApi.Services
{
    public interface IArtist
    {
        //CRUD operations
        IEnumerable<Artist> GetArtists();
        Artist GetArtist(int id);
        void AddArtist(Artist artist);
        void UpdateArtist(Artist artist);
        void DeleteArtist(int id);
    }
}
