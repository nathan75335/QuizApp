using QuizMaster.DataAccess.Entities;

namespace QuizMaster.DataAccess.Repositories.Interfaces;

public interface IAnswerOptionRepository
{
    Task<AnswerOption?> GetAnswerOptionByIdAsync(int id);
    Task<List<AnswerOption>> GetOptionsByQuestionIdAsync(int questionId);
    Task<List<AnswerOption>> GetAllAnswerOptionsAsync();
    Task<AnswerOption> AddAnswerOptionAsync(AnswerOption answerOption);
    Task<AnswerOption> UpdateAnswerOptionAsync(AnswerOption answerOption);
    Task<AnswerOption> DeleteAnswerOptionAsync(AnswerOption answerOption);
}
