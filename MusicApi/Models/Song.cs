using System.ComponentModel.DataAnnotations;

namespace MusicApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Title field is not empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Language field is not empty")]
        public string Language { get; set; }
        [Required(ErrorMessage = "The Duration field is not empty")]
        public string Duration { get; set; }
    }
}