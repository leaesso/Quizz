using Microsoft.EntityFrameworkCore;
using Quizz.Model;


namespace Quizz.Data
{
    namespace Quizz.Data
    {
        public class QuizDbContext : DbContext
        {
            public DbSet<ScoreEntry> Scores { get; set; }

            public QuizDbContext()
            {
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=quiz.db");
            }
        }
    }
}
