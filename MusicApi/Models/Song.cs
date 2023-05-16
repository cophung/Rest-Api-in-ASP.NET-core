using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Title field is not empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Duration field is not empty")]
        public string Duration { get; set; }
        public DateTime UploadeDate { get; set; }
        public bool IsFeatured { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile AudioFile { get; set; }
        public string AudioUrl { get; set; }
        public int? AlbumId { get; set;}
        public int ArtistId { get; set;}
    }
}