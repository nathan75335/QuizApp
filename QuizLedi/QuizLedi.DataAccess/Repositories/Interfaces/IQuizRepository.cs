using QuizLedi.DataAccess.Entities;

namespace QuizLedi.DataAccess.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        Task<List<Quiz>> GetQuizAsync();
        Task<Quiz> GetQuizByIdAsync(int id);
        Task<Quiz> AddAsync(Quiz quiz);
        Task<Quiz> UpdateAsync(Quiz quiz);
        Task<Quiz> DeleteAsync(Quiz quiz);
    }
}
