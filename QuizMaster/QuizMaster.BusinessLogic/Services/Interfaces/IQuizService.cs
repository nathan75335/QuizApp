using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;

namespace QuizMaster.BusinessLogic.Services.Interfaces;

public interface IQuizService
{
    Task<QuizDto> AddQuizAsync(QuizRequest request);
    Task<List<QuizDto>> GetQuizByCategoryIdAsync(int categoryId);
    Task<QuizDto> GetQuizByIdAsync(int quizId);
    Task<List<QuizDto>> GetAllQuizzesAsync();
    Task<QuizDto> UpdateQuizAsync(int id, QuizRequest request);
    Task<QuizDto> DeleteQuizAsync(int quizId);
}
