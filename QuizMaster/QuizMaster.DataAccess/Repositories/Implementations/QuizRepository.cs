using Microsoft.EntityFrameworkCore;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.DataAccess.Repositories.Implementations;

public class QuizRepository : IQuizRepository
{
    private readonly ApplicationDbContext _context;
    public QuizRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Quiz> AddQuizAsync(Quiz quiz)
    {
        _context.Quizzes.Add(quiz);
        await _context.SaveChangesAsync();

        return quiz;
    }

    public async Task<Quiz> DeleteQuizAsync(Quiz quiz)
    {
        _context.Quizzes.Remove(quiz);
        await _context.SaveChangesAsync();

        return quiz;
    }

    public async Task<List<Quiz>> GetAllQuizzesAsync()
    {
        return await _context.Quizzes.AsNoTracking().ToListAsync();
    }

    public async Task<Quiz?> GetQuizByIdAsync(int quizId)
    {
        return await _context.Quizzes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.QuizId == quizId);
    }

    public async Task<Quiz> UpdateQuizAsync(Quiz quiz)
    {
        _context.Quizzes.Update(quiz);
        await _context.SaveChangesAsync();
        
        return quiz;
    }
}
