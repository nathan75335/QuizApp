using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.DataAccess.Entities;

namespace QuizMaster.BusinessLogic.Services.Interfaces;

public interface IAnswerOptionService
{
    Task<List<AnswerOptionsDto>> GetOptionsByQuestionIdAsync(int questionId);
    Task<AnswerOptionsDto> AddAnswerOptionAsync(AnswerOptionRequest optionRequest);
    Task<AnswerOptionsDto> UpdateAnswerOption(AnswerOptionRequest answerOptionRequest);
    Task<AnswerOptionsDto> DeleteAnswerOptionAsync(AnswerOption optionRequest);
}
