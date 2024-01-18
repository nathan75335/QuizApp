using Microsoft.EntityFrameworkCore;
using QuizLedi.DataAccess.Data;
using QuizLedi.DataAccess.Entities;
using QuizLedi.DataAccess.Repositories.Interfaces;

namespace QuizLedi.DataAccess.Repositories.Implementations
{
    public class UserQuizRepository : IUserQuizRepository
    {
        private readonly DbContextQuiz _db;

        public UserQuizRepository(DbContextQuiz db)
        {
            _db = db;
        }

        public async Task<UserQuiz> AddAsync(UserQuiz userQuiz)
        {
            _db.UserQuizzes.Add(userQuiz);
            await _db.SaveChangesAsync();

            return userQuiz;
        }

        public async Task<UserQuiz>DeleteAsync(UserQuiz userQuiz)
        {
            _db.UserQuizzes.Remove(userQuiz);
            await _db.SaveChangesAsync();

            return userQuiz;
        }

        public async Task<List<UserQuiz>>GetUserQuizAsync()
        {
            return await _db.UserQuizzes.AsNoTracking().ToListAsync();
        }

        public async Task<UserQuiz> GetUserQuizByIdAsync(int id)
        {
            return await _db.UserQuizzes.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserQuiz>UpdateAsync(UserQuiz userQuiz)
        {
            _db.UserQuizzes.Update(userQuiz);
            await _db.SaveChangesAsync();

            return userQuiz;
        }
    }
}
