using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is not empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Gender field is not empty")]
        public string Gender { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
