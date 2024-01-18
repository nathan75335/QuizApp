using Microsoft.EntityFrameworkCore;
using QuizLedi.DataAccess.Data;
using QuizLedi.DataAccess.Entities;
using QuizLedi.DataAccess.Repositories.Interfaces;

namespace QuizLedi.DataAccess.Repositories.Implementations
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly DbContextQuiz _db;

        public ScoreRepository(DbContextQuiz db)
        {
            _db = db;
        }

        public async Task<Score>AddAsync(Score score)
        {
            _db.Scores.Add(score);
            await _db.SaveChangesAsync();

            return score;
        }

        public async Task<Score>DeleteAsync(Score score)
        {
            _db.Scores.Remove(score);
            await _db.SaveChangesAsync();

            return score;
        }

        public async Task<List<Score>>GetScoreAsync()
        {
            return await _db.Scores.AsNoTracking().ToListAsync();
        }

        public async Task<Score>GetScoreByIdAsync(int id)
        {
            return await _db.Scores.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Score>UpdateAsync(Score score)
        {
            _db.Scores.Update(score);
            await _db.SaveChangesAsync();

            return score;
        }
    }
}
