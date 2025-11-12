using Microsoft.EntityFrameworkCore;
using MovieApp.Data.Models;

namespace MovieApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Screening> Screenings => Set<Screening>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            b.Entity<Movie>(e =>
            {
                e.Property(p => p.Title).IsRequired().HasMaxLength(120);
                e.Property(p => p.Genre).HasMaxLength(60);
                e.Property(p => p.Synopsis).HasMaxLength(1000);
                e.Property(p => p.PosterUrl).HasMaxLength(300);
                e.HasIndex(p => new { p.Title, p.Year });
            });

            b.Entity<Screening>(e =>
            {
                e.Property(p => p.Hall).IsRequired().HasMaxLength(40);
                e.Property(p => p.Price).HasColumnType("decimal(10,2)");
                e.HasIndex(p => p.StartTime);

                e.HasOne(s => s.Movie)
                 .WithMany(m => m.Screenings)
                 .HasForeignKey(s => s.MovieId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
