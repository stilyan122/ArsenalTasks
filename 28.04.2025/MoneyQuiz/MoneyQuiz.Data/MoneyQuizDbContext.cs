using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data.Models;

namespace MoneyQuiz.Data
{
    public class MoneyQuizDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<PlayerGameSession> PlayerGameSessions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<PlayerAnswer> PlayerAnswers { get; set; }
        public DbSet<Lifeline> Lifelines { get; set; }

        public MoneyQuizDbContext()
        {
            
        }

        public MoneyQuizDbContext(DbContextOptions<MoneyQuizDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(p => p.PlayerGameSessions)
                .WithOne(pgs => pgs.Player)
                .HasForeignKey(pgs => pgs.PlayerId);

            modelBuilder.Entity<GameSession>()
                .HasMany(gs => gs.PlayerGameSessions)
                .WithOne(pgs => pgs.Session)
                .HasForeignKey(pgs => pgs.SessionId);

            modelBuilder.Entity<PlayerGameSession>()
                .HasMany(pgs => pgs.PlayerAnswers)
                .WithOne(pa => pa.PlayerSession)
                .HasForeignKey(pa => pa.PlayerSessionId);

            modelBuilder.Entity<PlayerGameSession>()
                .HasMany(pgs => pgs.Lifelines)
                .WithOne(l => l.PlayerGameSession)
                .HasForeignKey(l => l.PlayerGameSessionId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<Answer>()
                .HasMany(a => a.PlayerAnswers)
                .WithOne(pa => pa.Answer)
                .HasForeignKey(pa => pa.AnswerId);

            modelBuilder.Entity<Lifeline>()
                .HasOne(l => l.UsedOnQuestion)
                .WithMany()
                .HasForeignKey(l => l.UsedOnQuestionId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;" +
                "Database=MoneyQuiz;Integrated Security=true;" +
             "TrustServerCertificate=True;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
