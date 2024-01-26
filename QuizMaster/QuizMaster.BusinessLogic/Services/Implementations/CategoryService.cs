using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizMaster.BusinessLogic.Exceptions;
using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.BusinessLogic.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CategoryService> _logger;
    public CategoryService(ICategoryRepository categoryRepository, 
        IMapper mapper, ILogger<CategoryService> logger)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CategoryDto> AddCategoryAsync(CategoryRequest categoryRequest)
    {
        var category = await _categoryRepository
            .AddCategoryAsync(_mapper.Map<Category>(categoryRequest));

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> DeleteCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryById(id);
        if(category is null)
        {
            _logger.LogError("There is no any category with that id");
            throw new NotFoundException("There is not any category with such an id");
        }

        var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(category);

        return _mapper.Map<CategoryDto>(categoryDeleted);
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();

        return _mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryById(id);
        if( category is null )
        {
            _logger.LogError("There is no any category with that id");
            throw new NotFoundException("There is not any category with such an id");
        }

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> UpdateCategoryAsync(int id, CategoryRequest categoryRequest)
    {
        var category = await _categoryRepository.GetCategoryById(id);
        
        if(category is null)
        {
            _logger.LogError("There is no any category to update with that id");
            throw new NotFoundException("There is not any category to update with such an id");
        }

        _mapper.Map(categoryRequest, category);
        var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(category);

        return _mapper.Map<CategoryDto>(categoryUpdated);
    }
}
