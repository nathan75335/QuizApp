using QuizMaster.DataAccess.Entities;

namespace QuizMaster.DataAccess.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetCategoryById(int categoryId);
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task<Category> DeleteCategoryAsync(Category category);
}
