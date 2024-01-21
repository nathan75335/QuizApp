using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizMaster.BusinessLogic.Exceptions;
using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.BusinessLogic.Services.Implementations;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<QuestionService> _logger;

    public QuestionService(IQuestionRepository questionRepository, 
        IMapper mapper, ILogger<QuestionService> logger)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<QuestionDto> AddQuestionAsync(QuestionRequest questionRequest)
    {
        var question = await _questionRepository
            .AddQuestionAsync(_mapper.Map<Question>(questionRequest));

        return _mapper.Map<QuestionDto>(question);
    }

    public async Task<QuestionDto> DeleteQuestionAsync(QuestionRequest questionRequest)
    {
        var question = await _questionRepository.GetQuestionByIdAsync(questionRequest.Id);
        if(question is null)
        {
            _logger.LogError("There is not any question to delete with that id");
            throw new NotFoundException("There is not any question with such an id");
        }

        var deletedQuestion = await _questionRepository.DeleteQuestionAsync(question);

        return _mapper.Map<QuestionDto>(deletedQuestion);
    }

    public async Task<QuestionDto> GetQuestionByIdAsync(int questionId)
    {
        var question = await _questionRepository.GetQuestionByIdAsync(questionId);
        if(question is null)
        {
            _logger.LogError("There is not any question with that id");
            throw new NotFoundException("There is not any question with such an id");
        }

        return _mapper.Map<QuestionDto>(question);
    }

    public async Task<List<QuestionDto>> GetQuestionsByQuizAsync(int quizId)
    {
        var questions = await _questionRepository.GetQuestionByIdAsync(quizId);

        return _mapper.Map<List<QuestionDto>>(questions);
    }

    public async Task<List<QuestionDto>> GetAllQuestionsAsync()
    {
        var questions = await _questionRepository.GetAllQuestionsAsync();

        return _mapper.Map<List<QuestionDto>>(questions);
    }

    public async Task<QuestionDto> UpdateQuestionAsync(QuestionRequest questionRequest)
    {
        var question = await _questionRepository.GetQuestionByIdAsync(questionRequest.Id);
        if(question is null)
        {
            _logger.LogError("There is no any question to update with that id");
            throw new NotFoundException("There is not any question to update with such an id");
        }

        _mapper.Map(questionRequest, question);
        var questionUpdated = await _questionRepository.UpdateQuestionAsync(question);

        return _mapper.Map<QuestionDto>(question);
    }
}
