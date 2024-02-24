using QuizMaster.DataAccess.Entities;

namespace QuizMaster.DataAccess.Repositories.Interfaces;

public interface IQuizRepository
{
    Task<Quiz?> GetQuizByIdAsync(int quizId);
    Task<List<Quiz>> GetQuizByCategoryIdAsync(int categoryId);
    Task<List<Quiz>> GetAllQuizzesAsync();
    Task<Quiz> AddQuizAsync(Quiz quiz);
    Task<Quiz> UpdateQuizAsync(Quiz quiz);
    Task<Quiz> DeleteQuizAsync(Quiz quiz);
}
