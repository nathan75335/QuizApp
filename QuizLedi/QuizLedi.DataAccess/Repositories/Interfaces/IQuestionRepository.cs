using QuizLedi.DataAccess.Entities;

namespace QuizLedi.DataAccess.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(int id);
        Task<Question> AddAsync(Question question);
        Task<Question> UpdateAsync(Question question);
        Task<Question> DeleteAsync(Question question);
    }
}
