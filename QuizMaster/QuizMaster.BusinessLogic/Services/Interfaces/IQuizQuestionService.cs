using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;

namespace QuizMaster.BusinessLogic.Services.Interfaces;

public interface IQuizQuestionService
{
    Task<List<QuizQuestionDto>> GetQuestionsByQuizIdAsync(int quizId);
    Task<QuizQuestionDto> AddQuizQuestionAsync(UserQuizFormRequest userQuizFormRequest);
    Task<QuizQuestionDto> UpdateQuizQuestionAsync(int questionId, UserQuizFormRequest userQuizFormRequest);
    Task<QuizQuestionDto> DeleteQuizQuestionAsync(int questionId);
}
