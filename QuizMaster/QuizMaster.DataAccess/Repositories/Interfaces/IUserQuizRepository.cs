using QuizMaster.DataAccess.Entities;

namespace QuizMaster.DataAccess.Repositories.Interfaces;

public interface IUserQuizRepository
{
    Task<UserQuiz?> GetUserQuizByIdAsync(int id);
    Task<List<UserQuiz>> GetAllUserQuizzesAsync();
    Task<UserQuiz> AddUserQuizAsync(UserQuiz userQuiz);
    Task<UserQuiz> UpdateUserQuizAsync(UserQuiz userQuiz, List<UserAnswer> userAnswers);
    Task<UserQuiz> DeleteUserQuizAsync(UserQuiz userQuiz);
}
