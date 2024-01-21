using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizMaster.BusinessLogic.Exceptions;
using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.BusinessLogic.Services.Implementations;

public class UserQuizService : IUserQuizService
{
    private readonly IUserQuizRepository _userQuizRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UserQuizService> _logger;

    public UserQuizService(IUserQuizRepository userQuizRepository, IMapper mapper, ILogger<UserQuizService> logger)
    {
        _userQuizRepository = userQuizRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<UserQuizDto>> GetAllUserQuizzesAsync()
    {
        var userQuizzes = await _userQuizRepository.GetAllUserQuizzesAsync();

        return _mapper.Map<List<UserQuizDto>>(userQuizzes);
    }

    public async Task<UserQuizDto> GetUserQuizByIdAsync(int id)
    {
        var userQuiz = await _userQuizRepository.GetUserQuizByIdAsync(id);
        if(userQuiz is null)
        {
            _logger.LogError("There is no any category with that id");
            throw new NotFoundException("There is not any category with such an id");
        }

        return _mapper.Map<UserQuizDto>(userQuiz);
    }

    public async Task<UserQuizDto> StartUserQuizAsync(UserQuizRequest request)
    {
        var userQuiz = _mapper.Map<UserQuiz>(request);
        userQuiz.StartTime = DateTime.Now;

        // since StartUserQuizAsync does not require userAnswers, and it's expexting a list of answers
        // so i pass an empty list to UpdateUserQuizAsync
        var startedUserQuiz = await _userQuizRepository.UpdateUserQuizAsync(userQuiz, new List<UserAnswer>());

        return _mapper.Map<UserQuizDto>(startedUserQuiz);
    }

    public async Task<UserQuizDto> SubmitUserQuizResponseAsync(UserQuizRequest request, List<AnswerOptionRequest> selectedAnswers)
    {
        var userQuiz = _mapper.Map<UserQuiz>(request);
        userQuiz.EndTime = DateTime.Now;

        var userAnswers = selectedAnswers.Select(answer => new UserAnswer
        {
            QuestionId = answer.QuestionId,
            AnswerOptionId = answer.Id
        }).ToList();

        var submitedUserQuiz = await _userQuizRepository.UpdateUserQuizAsync(userQuiz, userAnswers);

        return _mapper.Map<UserQuizDto>(submitedUserQuiz);
    }
}
