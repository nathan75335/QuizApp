#region
using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizMaster.BusinessLogic.Exceptions;
using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;
#endregion
namespace QuizMaster.BusinessLogic.Services.Implementations;

public class QuizService : IQuizService
{
    private readonly IQuizRepository _quizRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<QuizService> _logger;

    public QuizService(IQuizRepository quizRepository, IMapper mapper, 
        ILogger<QuizService> logger)
    {
        _quizRepository = quizRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<QuizDto> AddQuizAsync(QuizRequest request)
    {
        var quiz = await _quizRepository.AddQuizAsync(_mapper.Map<Quiz>(request));

        return _mapper.Map<QuizDto>(quiz);
    }

    public async Task<QuizDto> DeleteQuizAsync(int quizId)
    {
        var quiz = await _quizRepository.GetQuizByIdAsync(quizId);
        if(quiz is null)
        {
            _logger.LogError("There is no any quiz with that id");
            throw new NotFoundException("There is not any quiz with such an id");
        }

        var quizDeleted = await _quizRepository.DeleteQuizAsync(quiz);

        return _mapper.Map<QuizDto>(quizDeleted);
    }

    public async Task<List<QuizDto>> GetAllQuizzesAsync()
    {
        var quizzes = await _quizRepository.GetAllQuizzesAsync();

        return _mapper.Map<List<QuizDto>>(quizzes);
    }

    public async Task<List<QuizDto>> GetQuizByCategoryIdAsync(int categoryId)
    {
        var quizCategories = await _quizRepository.GetQuizByCategoryIdAsync(categoryId);

        return _mapper.Map<List<QuizDto>>(quizCategories);
    }

    public async Task<QuizDto> GetQuizByIdAsync(int quizId)
    {
        var quiz = await _quizRepository.GetQuizByIdAsync(quizId);
        if(quiz is null)
        {
            _logger.LogError("There is no quiz with that id");
            throw new NotFoundException("There is not any quiz with such an id");
        }

        return _mapper.Map<QuizDto>(quiz);
    }

    public async Task<QuizDto> UpdateQuizAsync(int id, QuizRequest request)
    {
        var quiz = await _quizRepository.GetQuizByIdAsync(id);
        if(quiz is null)
        {
            _logger.LogError("There is no quiz to update with that id");
            throw new NotFoundException("There is not any quiz with such an id");
        }

        _mapper.Map(request, quiz);
        var quizUpdated = await _quizRepository.UpdateQuizAsync(quiz);

        return _mapper.Map<QuizDto>(quizUpdated);
    }
}
