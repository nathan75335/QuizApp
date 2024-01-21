using Microsoft.EntityFrameworkCore;
using QuizMaster.DataAccess.Entities;

namespace QuizMaster.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
        
    }

    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserQuiz> UserQuizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AnswerOption> Answers { get; set; }
    public DbSet<Role> Roles { get; set; }

    //configures the delete behaviors for each relationship
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserQuiz>()
            .HasOne(uq => uq.User)
            .WithMany(u => u.TakenQuizzes)
            .HasForeignKey(uq => uq.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserQuiz>()
            .HasOne(uq => uq.Quiz)
            .WithMany()
            .HasForeignKey(uq => uq.QuizId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserAnswer>()
            .HasOne(ua => ua.UserQuiz)
            .WithMany(uq => uq.UserAnswers)
            .HasForeignKey(ua => ua.UserQuizId);

        modelBuilder.Entity<UserAnswer>()
            .HasOne(ua => ua.Question)
            .WithMany()
            .HasForeignKey(ua => ua.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserAnswer>()
            .HasOne(ua => ua.AnswerOption)
            .WithMany()
            .HasForeignKey(ua => ua.AnswerOptionId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Question>()
            .HasOne(q => q.Quiz)
            .WithMany(qz => qz.Questions)
            .HasForeignKey(q => q.QuizId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<AnswerOption>()
            .HasOne(ao => ao.Question)
            .WithMany(q => q.Options)
            .HasForeignKey(ao => ao.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Quiz>()
            .HasOne(q => q.Category)
            .WithMany(c => c.Quizzes)
            .HasForeignKey(q => q.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<User>()
            .HasIndex(user => user.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasKey(user => user.UserId);

        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
            new Role
            {
                Id = -2,
                Name = "User"
            },

            new Role
            {
                Id = -1,
                Name = "Admin"
            }
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            UserId = -1,
            UserName = "Aristote",
            Email = "arisdev@gmail.com",
            Password = "Aristote654321",
            RoleId = -1
        });

        base.OnModelCreating(modelBuilder);
    }

}
