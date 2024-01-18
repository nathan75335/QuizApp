using Microsoft.EntityFrameworkCore;
using QuizLedi.DataAccess.Data;
using QuizLedi.DataAccess.Entities;
using QuizLedi.DataAccess.Repositories.Interfaces;

namespace QuizLedi.DataAccess.Repositories.Implementations
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DbContextQuiz _db;

        public QuestionRepository(DbContextQuiz db)
        {
            _db = db;
        }

        public async Task<Question>AddAsync(Question question)
        {
            _db.Questions.Add(question);
            await _db.SaveChangesAsync();

            return question;
        }

        public async Task<Question>DeleteAsync(Question question)
        {
            _db.Questions.Remove(question);
            await _db.SaveChangesAsync();

            return question;
        }

        public async Task<List<Question>>GetAllQuestionsAsync()
        {
            return await _db.Questions.AsNoTracking().ToListAsync();
        }

        public async Task<Question>GetQuestionByIdAsync(int id)
        {
            return await _db.Questions.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Question>UpdateAsync(Question question)
        {
            _db.Questions.Update(question);
            await _db.SaveChangesAsync();

            return question;
        }
    }
}
