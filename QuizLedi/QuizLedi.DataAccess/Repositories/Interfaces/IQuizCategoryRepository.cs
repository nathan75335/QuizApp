using QuizLedi.DataAccess.Entities;

namespace QuizLedi.DataAccess.Repositories.Interfaces
{
    public interface IQuizCategoryRepository
    {
        Task<List<QuizCategory>> GetQuizCategoryAsync();
        Task<QuizCategory> GetQuizCategoryByIdAsync(int id);
        Task<QuizCategory> AddAsync(QuizCategory quizCat);
        Task<QuizCategory> UpdateAsync(QuizCategory quizCat);
        Task<QuizCategory> DeleteAsync(QuizCategory quizCat);
    }
}
