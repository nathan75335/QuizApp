using Microsoft.EntityFrameworkCore;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.DataAccess.Repositories.Implementations;

public class AnswerOptionRepository : IAnswerOptionRepository
{
    private readonly ApplicationDbContext _context;
    public AnswerOptionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AnswerOption> AddAnswerOptionAsync(AnswerOption answerOption)
    {
        _context.Answers.Add(answerOption);
        await _context.SaveChangesAsync();

        return answerOption;
    }

    public async Task<AnswerOption> DeleteAnswerOptionAsync(AnswerOption answerOption)
    {
        _context.Answers.Remove(answerOption);
        await _context.SaveChangesAsync();

        return answerOption;
    }

    public async Task<AnswerOption?> GetAnswerOptionByIdAsync(int id)
    {
        return await _context.Answers.AsNoTracking().FirstOrDefaultAsync(x => x.OptionId == id);
    }

    public async Task<List<AnswerOption>> GetAllAnswerOptionsAsync()
    {
       return await _context.Answers.AsNoTracking().ToListAsync();
    }

    public async Task<AnswerOption> UpdateAnswerOptionAsync(AnswerOption answerOption)
    {
        _context.Answers.Update(answerOption);
        await _context.SaveChangesAsync();

        return answerOption;
    }

    public async Task<AnswerOption?> GetOptionsByQuestionIdAsync(int questionId)
    {
        return await _context.Answers.AsNoTracking().FirstOrDefaultAsync(x => x.QuestionId == questionId);
    }
}
