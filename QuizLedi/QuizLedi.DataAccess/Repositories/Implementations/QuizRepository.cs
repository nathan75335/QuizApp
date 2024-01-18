using Microsoft.EntityFrameworkCore;
using QuizLedi.DataAccess.Data;
using QuizLedi.DataAccess.Entities;
using QuizLedi.DataAccess.Repositories.Interfaces;

namespace QuizLedi.DataAccess.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly DbContextQuiz _db;
        public QuizRepository(DbContextQuiz db)
        {
            _db = db;
        }

        public async Task<Quiz> AddAsync(Quiz quiz)
        {
            _db.Quizzes.Add(quiz);
            await _db.SaveChangesAsync();

            return quiz;
        }

        public async Task<Quiz> DeleteAsync(Quiz quiz)
        {
            _db.Quizzes.Remove(quiz);
            await _db.SaveChangesAsync();

            return quiz;
        }

        public async Task<List<Quiz>> GetQuizAsync()
        {
            return await _db.Quizzes.AsNoTracking().ToListAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(int id)
        {
            return await _db.Quizzes.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Quiz> UpdateAsync(Quiz quiz)
        {
            _db.Quizzes.Update(quiz);
            await _db.SaveChangesAsync();

            return quiz;
        }
    }
}
