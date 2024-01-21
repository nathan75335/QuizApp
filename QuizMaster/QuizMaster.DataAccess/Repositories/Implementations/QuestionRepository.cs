using Microsoft.EntityFrameworkCore;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.DataAccess.Repositories.Implementations;

public class QuestionRepository : IQuestionRepository
{
    private readonly ApplicationDbContext _context;
    public QuestionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Question> AddQuestionAsync(Question question)
    {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return question;
    }

    public async Task<Question> DeleteQuestionAsync(Question question)
    {
        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();

        return question;
    }

    public async Task<List<Question>> GetAllQuestionsAsync()
    {
        return await _context.Questions.AsNoTracking().ToListAsync();
    }

    public async Task<Question?> GetQuestionByIdAsync(int id)
    {
        return await _context.Questions
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.QuestionId == id);
    }

    public async Task<Question> UpdateQuestionAsync(Question question)
    {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return question;
    }
}
