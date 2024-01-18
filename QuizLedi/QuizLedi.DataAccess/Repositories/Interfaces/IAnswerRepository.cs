using QuizLedi.DataAccess.Entities;

namespace QuizLedi.DataAccess.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAllAnswerAsync();
        Task<Answer> GetAnswerByIdAsync(int id);
        Task<Answer> AddAsync(Answer answer);
        Task<Answer> UpdateAsync(Answer answer);
        Task<Answer> DeleteAsync(Answer answer);
    }
}
