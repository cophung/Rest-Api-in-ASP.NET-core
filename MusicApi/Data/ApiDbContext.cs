using Microsoft.EntityFrameworkCore;
using MusicApi.Models;

namespace MusicApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public DbSet<Song> Songs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(new Song
            {
                Id = 1,
                Title = "1",
                Language = "en",
                Duration = "4:30"
            },
            new Song
            {
                Id = 2,
                Title = "2",
                Language = "en",
                Duration = "4:00"
            });
        }
    }
}
