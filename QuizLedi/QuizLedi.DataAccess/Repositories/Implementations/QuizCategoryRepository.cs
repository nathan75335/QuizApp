using Microsoft.EntityFrameworkCore;
using QuizLedi.DataAccess.Data;
using QuizLedi.DataAccess.Entities;
using QuizLedi.DataAccess.Repositories.Interfaces;

namespace QuizLedi.DataAccess.Repositories.Implementations
{
    public class QuizCategoryRepository : IQuizCategoryRepository
    {
        private readonly DbContextQuiz _db;
        public QuizCategoryRepository(DbContextQuiz db)
        {
            _db = db;
        }

        public async Task<QuizCategory> AddAsync(QuizCategory quizCat)
        {
            _db.QuizCategories.Add(quizCat);
            await _db.SaveChangesAsync();

            return quizCat;
        }

        public async Task<QuizCategory> DeleteAsync(QuizCategory quizCat)
        {
            _db.QuizCategories.Remove(quizCat);
            await _db.SaveChangesAsync();

            return quizCat;
        }

        public async Task<List<QuizCategory>> GetQuizCategoryAsync()
        {
            return await _db.QuizCategories.AsNoTracking().ToListAsync();
        }

        public async Task<QuizCategory> GetQuizCategoryByIdAsync(int id)
        {
            return await _db.QuizCategories.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<QuizCategory> UpdateAsync(QuizCategory quizCat)
        {
            _db.QuizCategories.Update(quizCat);
            await _db.SaveChangesAsync();

            return quizCat;
        }
    }
}
