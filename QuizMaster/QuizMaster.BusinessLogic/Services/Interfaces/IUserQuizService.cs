﻿using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;

namespace QuizMaster.BusinessLogic.Services.Interfaces;

public interface IUserQuizService
{
    Task<UserQuizDto> GetUserQuizByIdAsync(int userQuizId);
    Task<UserQuizDto> AddUserQuizAsync(UserQuizRequest userQuizRequest);
    Task<UserQuizDto> UpdateUserQuizAsync(int userQuizId, UserQuizRequest userQuizRequest);
    Task<UserQuizDto> DeleteUserQuizAsync(int userQuizId);
}
