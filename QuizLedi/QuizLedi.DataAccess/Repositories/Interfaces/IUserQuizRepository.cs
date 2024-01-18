using QuizLedi.DataAccess.Entities;

namespace QuizLedi.DataAccess.Repositories.Interfaces
{
    public interface IUserQuizRepository
    {
        Task<List<UserQuiz>> GetUserQuizAsync();
        Task<UserQuiz> GetUserQuizByIdAsync(int id);
        Task<UserQuiz> AddAsync(UserQuiz userQuiz);
        Task<UserQuiz> UpdateAsync(UserQuiz userQuiz);
        Task<UserQuiz> DeleteAsync(UserQuiz userQuiz);
    }
}
