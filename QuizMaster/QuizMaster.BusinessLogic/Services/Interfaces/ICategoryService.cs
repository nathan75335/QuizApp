using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;

namespace QuizMaster.BusinessLogic.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(int id);
    Task<CategoryDto> AddCategoryAsync(CategoryRequest categoryRequest);
    Task<CategoryDto> UpdateCategoryAsync(int id, CategoryRequest categoryRequest);
    Task<CategoryDto> DeleteCategoryAsync(int id);
}
