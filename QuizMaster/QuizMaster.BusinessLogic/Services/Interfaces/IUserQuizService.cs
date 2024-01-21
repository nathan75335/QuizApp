using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;

namespace QuizMaster.BusinessLogic.Services.Interfaces;

public interface IUserQuizService
{
    Task<UserQuizDto> StartUserQuizAsync(UserQuizRequest request);
    Task<UserQuizDto> GetUserQuizByIdAsync(int id);
    Task<List<UserQuizDto>> GetAllUserQuizzesAsync();
    Task<UserQuizDto> SubmitUserQuizResponseAsync(UserQuizRequest request, List<AnswerOptionRequest> selectedAnswers);
}
