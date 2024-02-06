using Microsoft.EntityFrameworkCore;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.DataAccess.Repositories.Implementations;

public class UserQuizRepository : IUserQuizRepository
{
    private readonly ApplicationDbContext _context;
    public UserQuizRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserQuiz> AddUserQuizAsync(UserQuiz userQuiz)
    {
        _context.UserQuizzes.Add(userQuiz);
        await _context.SaveChangesAsync();

        return userQuiz;
    }

    public async Task<UserQuiz> DeleteUserQuizAsync(UserQuiz userQuiz)
    {
        _context.UserQuizzes.Remove(userQuiz);
        await _context.SaveChangesAsync();

        return userQuiz;
    }

    public async Task<List<UserQuiz>> GetAllUserQuizzesAsync()
    {
        return await _context.UserQuizzes
            .Include(u => u.User)
            .Include(q => q.Quiz)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<UserQuiz?> GetUserQuizByIdAsync(int id)
    {
        return await _context.UserQuizzes.AsNoTracking().FirstOrDefaultAsync(x => x.UserQuizId == id);
    }

    public async Task<UserQuiz> UpdateUserQuizAsync(UserQuiz userQuiz)
    {
        _context.UserQuizzes.Update(userQuiz);
        await _context.SaveChangesAsync();

        return userQuiz;
    }
}
