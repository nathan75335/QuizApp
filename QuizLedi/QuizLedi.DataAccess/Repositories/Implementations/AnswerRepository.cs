using Microsoft.EntityFrameworkCore;
using QuizLedi.DataAccess.Data;
using QuizLedi.DataAccess.Entities;
using QuizLedi.DataAccess.Repositories.Interfaces;

namespace QuizLedi.DataAccess.Repositories.Implementations
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly DbContextQuiz _db;
        public AnswerRepository(DbContextQuiz db) 
        {
            _db = db;
        }
        public async Task<Answer> AddAsync(Answer answer)
        {
            _db.Answers.Add(answer);
            await _db.SaveChangesAsync();

            return answer;
        }

        public async Task<Answer> DeleteAsync(Answer answer)
        {
            _db.Answers.Remove(answer); 
            await _db.SaveChangesAsync();

            return answer;
        }

        public async Task<List<Answer>>GetAllAnswerAsync()
        {
            return await _db.Answers.
                        AsNoTracking().
                        ToListAsync();
        }

        public async Task<Answer>GetAnswerByIdAsync(int id)
        {
            return await _db.Answers.AsNoTracking().
                                     FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Answer>UpdateAsync(Answer answer)
        {
            _db.Answers.Update(answer);
            await _db.SaveChangesAsync();

            return answer;
        }
    }
}
