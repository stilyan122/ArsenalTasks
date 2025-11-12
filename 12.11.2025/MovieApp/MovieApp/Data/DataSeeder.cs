using Microsoft.EntityFrameworkCore;
using MovieApp.Data.Models;

namespace MovieApp.Data
{
    public class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext db)
        {
            if (!await db.Movies.AnyAsync())
            {
                db.Movies.AddRange(
                    new Movie { Title = "Interstellar", Genre = "Sci-Fi", Year = 2014, Synopsis = "A team travels through a wormhole...", PosterUrl = "https://picsum.photos/seed/inter/300/450" },
                    new Movie { Title = "Inception", Genre = "Thriller", Year = 2010, Synopsis = "Dream-heist specialist faces his past.", PosterUrl = "https://picsum.photos/seed/inception/300/450" },
                    new Movie { Title = "The Dark Knight", Genre = "Action", Year = 2008, Synopsis = "Batman vs Joker.", PosterUrl = "https://picsum.photos/seed/tdk/300/450" }
                );
                await db.SaveChangesAsync();
            }

            if (!await db.Screenings.AnyAsync())
            {
                var inter = await db.Movies.Where(m => m.Title == "Interstellar").Select(m => m.Id).FirstAsync();
                var inception = await db.Movies.Where(m => m.Title == "Inception").Select(m => m.Id).FirstAsync();

                db.Screenings.AddRange(
                    new Screening { MovieId = inter, StartTime = DateTime.UtcNow.AddHours(6), Hall = "IMAX", Price = 15.50m },
                    new Screening { MovieId = inception, StartTime = DateTime.UtcNow.AddDays(1).AddHours(2), Hall = "Hall 2", Price = 12.00m }
                );
                await db.SaveChangesAsync();
            }
        }
    }
}
