using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;

namespace QuizMaster.BusinessLogic.Services.Interfaces;

public interface IQuestionService
{
    Task<QuestionDto> GetQuestionByIdAsync(int questionId);
    Task<List<QuestionDto>> GetQuestionOptionsByIdAsync(int id);
    Task<List<QuestionDto>> GetQuestionsByQuizAsync(int quizId);
    Task<List<QuestionDto>> GetAllQuestionsAsync();
    Task<QuestionDto> AddQuestionAsync(QuestionRequest questionRequest);
    Task<QuestionDto> UpdateQuestionAsync(int id, QuestionRequest questionRequest);
    Task<QuestionDto> DeleteQuestionAsync(int id);
}
