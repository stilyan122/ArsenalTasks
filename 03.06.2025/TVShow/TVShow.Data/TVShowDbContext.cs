using Microsoft.EntityFrameworkCore;
using System;
using TVShow.Data.Models;

namespace TVShow.Data
{
    public class TVShowDbContext : DbContext
    {
        public DbSet<Show> Shows { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }

        public TVShowDbContext()
        {
            
        }

        public TVShowDbContext(DbContextOptions<TVShowDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Database=TVShow; Integrated Security = True; Connect Timeout = 30; Encrypt = True;Trust Server Certificate=False; Application Intent = ReadWrite; Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Show>()
                .HasMany(s => s.Quizzes)
                .WithOne(q => q.Show)
                .HasForeignKey(q => q.ShowId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(qn => qn.Quiz)
                .HasForeignKey(qn => qn.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Show>()
                .HasMany(s => s.Contestants)
                .WithMany(c => c.Shows)
                .UsingEntity<Dictionary<string, object>>(
                    "ShowContestant", 
                    j => j
                        .HasOne<Contestant>()
                        .WithMany()
                        .HasForeignKey("ContestantId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Show>()
                        .WithMany()
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("ShowId", "ContestantId");
                        j.ToTable("ShowContestants");
                        j.HasIndex("ContestantId");
                        j.HasIndex("ShowId");
                    });

            modelBuilder.Entity<Show>()
                .HasIndex(s => s.Name)
                .IsUnique(false);

            modelBuilder.Entity<Contestant>()
                .HasIndex(c => c.ContactEmail)
                .IsUnique(false);

            modelBuilder.Entity<Quiz>()
                .HasIndex(q => new { q.Title, q.ShowId })
                .IsUnique(true); 

            modelBuilder.Entity<Question>()
                .HasIndex(q => new { q.QuizId, q.Text })
                .IsUnique(false); 
        }
    }
}
