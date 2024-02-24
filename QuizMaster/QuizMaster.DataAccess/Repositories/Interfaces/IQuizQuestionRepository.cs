using QuizMaster.DataAccess.Entities;

namespace QuizMaster.DataAccess.Repositories.Interfaces;

public interface IQuizQuestionRepository
{
    Task<QuizQuestion?> GetQuizQuestionByIdAsync(int id);
    Task<List<QuizQuestion>> GetAllQuizQuestionsAsync();
    Task<List<QuizQuestion>> GetQuestionsByQuizIdAsync(int quizId);
    Task<QuizQuestion> AddQuizQuestionAsync(QuizQuestion quizQuestion);
    Task<QuizQuestion> UpdateQuizQuestionAsync(QuizQuestion quizQuestion);
    Task<QuizQuestion> DeleteQuizQuestionAsync(QuizQuestion quizQuestion);
}
