using Microsoft.EntityFrameworkCore;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.DataAccess.Repositories.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category> DeleteCategoryAsync(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
       return await _context.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<Category?> GetCategoryById(int categoryId)
    {
        return await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.CategoryId == categoryId);
    }

    public async Task<List<Category>> GetCategoryByQuizIdAsync(int quizId)
    {
        return await _context.Categories
            .Include(q => q.Quizzes)
            //.Where(q => q.CategoryId == quizId)
            .ToListAsync();
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();

        return category;
    }
}
