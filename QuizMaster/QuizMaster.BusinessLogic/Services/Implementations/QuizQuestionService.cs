using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizMaster.BusinessLogic.Exceptions;
using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.BusinessLogic.Services.Implementations;

public class QuizQuestionService : IQuizQuestionService
{
    private readonly IQuizQuestionRepository _quizQuestionRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<QuizQuestionService> _logger;

    public QuizQuestionService(IQuizQuestionRepository quizQuestionRepository, IMapper mapper, ILogger<QuizQuestionService> logger)
    {
        _quizQuestionRepository = quizQuestionRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<QuizQuestionDto> AddQuizQuestionAsync(UserQuizFormRequest userQuizFormRequest)
    {
        var question = await _quizQuestionRepository.AddQuizQuestionAsync(_mapper.Map<QuizQuestion>(userQuizFormRequest));
        
        return _mapper.Map<QuizQuestionDto>(question);
    }

    public async Task<QuizQuestionDto> DeleteQuizQuestionAsync(int questionId)
    {
        var result = await _quizQuestionRepository.GetQuizQuestionByIdAsync(questionId);

        if(result is null)
        {
            _logger.LogError("There is no any quizQuestion with that id");
            throw new NotFoundException("There is not any QuizQuestion with such an id");
        }

        var quizDeleted = await _quizQuestionRepository.DeleteQuizQuestionAsync(result);
        
        return _mapper.Map<QuizQuestionDto>(quizDeleted);
    }

    public async Task<List<QuizQuestionDto>> GetAllQuizQuestionsAsync()
    {
        var quizQuestions = await _quizQuestionRepository.GetAllQuizQuestionsAsync();

        return _mapper.Map<List<QuizQuestionDto>>(quizQuestions);
    }
    public async Task<List<QuizQuestionDto>> GetQuestionsByQuizIdAsync(int quizId)
    {
        var questions = await _quizQuestionRepository.GetQuestionsByQuizIdAsync(quizId);
        
        return _mapper.Map<List<QuizQuestionDto>>(questions);
    }

    public async Task<QuizQuestionDto> UpdateQuizQuestionAsync(int questionId, UserQuizFormRequest userQuizFormRequest)
    {
        var question = await _quizQuestionRepository.GetQuizQuestionByIdAsync(questionId);
        
        if (question == null)
        {
            _logger.LogError("There is no any quizquestion with that id");
            throw new NotFoundException("There is not any quizquestion with such an id");
        }

        _mapper.Map(userQuizFormRequest, question);
        var updatedQuestion = await _quizQuestionRepository.UpdateQuizQuestionAsync(question);
        
        return _mapper.Map<QuizQuestionDto>(updatedQuestion);
    }
}