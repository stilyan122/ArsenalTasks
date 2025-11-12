using Microsoft.EntityFrameworkCore;
using MoviesData.Entities;

namespace MoviesData
{
    public class MoviesDBContext : DbContext
    {
        public MoviesDBContext(DbContextOptions<MoviesDBContext> options)
            : base(options)
        {  
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
