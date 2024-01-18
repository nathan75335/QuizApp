using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuizLedi.DataAccess.Entities;
using System.Reflection.Emit;

namespace QuizLedi.DataAccess.Data
{
    public class DbContextQuiz:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserQuiz> UserQuizzes { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<QuizCategory> QuizCategories { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Assertion> Assertions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbContextQuiz(DbContextOptions options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}
