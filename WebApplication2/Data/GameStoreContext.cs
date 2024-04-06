using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.Data;

public class GameStoreContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Fighting" },
            new { Id = 2, Name = "roleplaying" },
            new { Id = 3, Name = "sports" },
            new { Id = 4, Name = "racing" },
            new { Id = 5, Name = "kids" }

        );
    }

}
