﻿#region
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

public class UserQuizService : IUserQuizService
{
    private readonly IUserQuizRepository _userQuizRepository;
    private readonly IQuizRepository _quizRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UserQuizService> _logger;
    private readonly IAnswerOptionRepository _answerOptionRepository;
    public UserQuizService(IUserQuizRepository userQuizRepository, IMapper mapper,
        ILogger<UserQuizService> logger, IAnswerOptionRepository answerOptionRepository, IQuizRepository quizRepository)
    {
        _userQuizRepository = userQuizRepository;
        _mapper = mapper;
        _logger = logger;
        _answerOptionRepository = answerOptionRepository;
        _quizRepository = quizRepository;
    }

    public async Task<UserQuizDto> AddUserQuizAsync(UserQuizRequest userQuizRequest)
    {
        var userQuiz = await _userQuizRepository.AddUserQuizAsync(_mapper.Map<UserQuiz>(userQuizRequest));
        //var score = await CalculateScore(userQuizRequest.QuizId, userQuizRequest.UserId, userQuizRequest.Answers);
        //userQuiz.Score = score;
        return _mapper.Map<UserQuizDto>(userQuiz);
    }

    public async Task<UserQuizDto> DeleteUserQuizAsync(int userQuizId)
    {
        var result = await _userQuizRepository.GetUserQuizByIdAsync(userQuizId);

        if (result is null)
        {
            _logger.LogError("There is no any user with that id");
            throw new NotFoundException("There is not any user with such an id");
        }

        var userQuizDeleted = await _userQuizRepository.DeleteUserQuizAsync(result);

        return _mapper.Map<UserQuizDto>(userQuizDeleted);
    }
    public async Task<List<UserQuizDto>> GetAllUserQuizzesAsync()
    {
        var userQuizzes = await _userQuizRepository.GetAllUserQuizzesAsync();

        return _mapper.Map<List<UserQuizDto>>(userQuizzes);
    }

    public async Task<UserQuizDto> GetUserQuizByIdAsync(int id)
    {
        var userQuiz = await _userQuizRepository.GetUserQuizByIdAsync(id);
        if (userQuiz is null)
        {
            _logger.LogError("There is no any user with that id");
            throw new NotFoundException("There is not any user with such an id");
        }

        return _mapper.Map<UserQuizDto>(userQuiz);
    }
    public async Task<UserQuizDto> UpdateUserQuizAsync(int userQuizId, UserQuizRequest userQuizRequest)
    {
        var userQuiz = await _userQuizRepository.GetUserQuizByIdAsync(userQuizId);
        if (userQuiz == null)
        {
            _logger.LogError("There is no any user with that id");
            throw new NotFoundException("There is not any user with such an id");
        }

        _mapper.Map(userQuizRequest, userQuiz);
        var updatedUserQuiz = await _userQuizRepository.UpdateUserQuizAsync(userQuiz);
        return _mapper.Map<UserQuizDto>(updatedUserQuiz);
    }

    public async Task<int> CalculateScoreAsync(UserQuizFormRequest userQuizFormRequest)
    {
        var quiz = await _quizRepository.GetQuizByIdAsync(userQuizFormRequest.QuizId);
        if (quiz == null)
        {
            _logger.LogError("There is no any quiz with that id");
            throw new NotFoundException("There is not any quiz with such an id");
        }

        var totalScore = 0;
        foreach (var userAnswer in userQuizFormRequest.QuizQuestions)
        {
            var answer = await _answerOptionRepository.GetAnswerOptionByIdAsync(userAnswer.AnswerId);
            if (answer.QuestionId == userAnswer.QuestionId && answer.IsCorrect)
            {
                totalScore += answer.Question.Point;
            }
        }

        return totalScore;
    }
}
