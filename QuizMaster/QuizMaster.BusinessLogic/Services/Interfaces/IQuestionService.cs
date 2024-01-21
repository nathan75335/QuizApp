﻿using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;

namespace QuizMaster.BusinessLogic.Services.Interfaces;

public interface IQuestionService
{
    Task<QuestionDto> GetQuestionByIdAsync(int questionId);
    Task<List<QuestionDto>> GetQuestionsByQuizAsync(int quizId);
    Task<List<QuestionDto>> GetAllQuestionsAsync();
    Task<QuestionDto> AddQuestionAsync(QuestionRequest questionRequest);
    Task<QuestionDto> UpdateQuestionAsync(QuestionRequest questionRequest);
    Task<QuestionDto> DeleteQuestionAsync(QuestionRequest questionRequest);
}
