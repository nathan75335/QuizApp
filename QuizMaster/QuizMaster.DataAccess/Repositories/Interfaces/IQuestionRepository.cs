using QuizMaster.DataAccess.Entities;

namespace QuizMaster.DataAccess.Repositories.Interfaces; 

public interface IQuestionRepository
{
    Task<Question?> GetQuestionByIdAsync(int id);
    Task<List<Question>> GetQuestionOptionsByIdAsync(int id);
    Task<List<Question>> GetAllQuestionsAsync();
    Task<Question> AddQuestionAsync(Question question);
    Task<Question> UpdateQuestionAsync(Question question);
    Task<Question> DeleteQuestionAsync(Question question);

}
