using QuizLedi.DataAccess.Entities;

namespace QuizLedi.DataAccess.Repositories.Interfaces
{
    public interface IScoreRepository
    {
        Task<List<Score>> GetScoreAsync();
        Task<Score> GetScoreByIdAsync(int id);
        Task<Score> AddAsync(Score score);
        Task<Score> UpdateAsync(Score score);
        Task<Score> DeleteAsync(Score score);
    }
}
