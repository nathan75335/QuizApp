using Microsoft.EntityFrameworkCore;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.DataAccess.Repositories.Implementations;

public class QuizQuestionRepository : IQuizQuestionRepository
{
    private readonly ApplicationDbContext _context;

    public QuizQuestionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<QuizQuestion> AddQuizQuestionAsync(QuizQuestion quizQuestion)
    {
        _context.QuizQuestions.Add(quizQuestion);
        await _context.SaveChangesAsync();

        return quizQuestion;
    }

    public async Task<QuizQuestion> DeleteQuizQuestionAsync(QuizQuestion quizQuestion)
    {
        _context.QuizQuestions.Remove(quizQuestion);
        await _context.SaveChangesAsync();

        return quizQuestion;
    }

    public async Task<List<QuizQuestion>> GetAllQuizQuestionsAsync()
    {
        return await _context.QuizQuestions
            .Include(q => q.Question)
            .Include(ap => ap.AnswerOption)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<QuizQuestion?> GetQuizQuestionByIdAsync(int id)
    {
        return await _context.QuizQuestions.FirstOrDefaultAsync(x => x.QuestionId == id);
    }

    public async Task<List<QuizQuestion>> GetQuestionsByQuizIdAsync(int quizId)
    {
        return await _context.QuizQuestions
                .Include(qq => qq.AnswerOption)
                .Where(qq => qq.Question.QuizId == quizId)
                .ToListAsync();
    }

    public async Task<QuizQuestion> UpdateQuizQuestionAsync(QuizQuestion quizQuestion)
    {
        _context.QuizQuestions.Update(quizQuestion);
        await _context.SaveChangesAsync();

        return quizQuestion;
    }
}

