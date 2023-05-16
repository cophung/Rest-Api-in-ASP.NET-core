using Microsoft.EntityFrameworkCore;
using MusicApi.Models;

namespace MusicApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) // dùng để khởi tạo data: chạy bằng package manager console: Add-Migration InitialCreate -> Add-Migration SeedSongsTable -> update-database
        //{
        //    modelBuilder.Entity<Song>().HasData(new Song
        //    {
        //        Id = 1,
        //        Title = "1",
        //        Language = "en",
        //        Duration = "4:30"
        //    },
        //    new Song
        //    {
        //        Id = 2,
        //        Title = "2",
        //        Language = "en",
        //        Duration = "4:00"
        //    });
        //}
    }
}
