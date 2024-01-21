﻿using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;

namespace QuizMaster.BusinessLogic.Services.Interfaces;

public interface IQuizService
{
    Task<QuizDto> AddQuizAsync(QuizRequest request);
    Task<QuizDto> GetQuizByIdAsync(int quizId);
    Task<List<QuizDto>> GetAllQuizzesAsync();
    Task<QuizDto> UpdateQuizAsync(QuizRequest request);
    Task<QuizDto> DeleteQuizAsync(int quizId);
}
