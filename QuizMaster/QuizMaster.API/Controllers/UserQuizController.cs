﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;

namespace QuizMaster.API.Controllers
{
    [Route("api/userquizzes")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class UserQuizController : ControllerBase
    {
        private readonly IUserQuizService _userQuizService;
        public UserQuizController(IUserQuizService userQuizService)
        {
            _userQuizService = userQuizService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserQuizzes()
        {
            var userQuizzes = await _userQuizService.GetAllUserQuizzesAsync();

            return Ok(userQuizzes);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUserQuiz(UserQuizRequest userQuizRequest)
        {
            var userQuiz = await _userQuizService.AddUserQuizAsync(userQuizRequest);

            return Ok(userQuiz);
        }

        [HttpPost("calculate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Result(UserQuizFormRequest userQuizFormRequest)
        {
            var result = await _userQuizService.CalculateScoreAsync(userQuizFormRequest);

            return Ok(result);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUserQuiz(int id, UserQuizRequest userQuizRequest)
        {
            var userQuiz = await _userQuizService.UpdateUserQuizAsync(id, userQuizRequest);

            return Ok(userQuiz);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUserQuiz(int id)
        {
            var userQuiz = await _userQuizService.DeleteUserQuizAsync(id);

            return Ok(userQuiz);
        }

    }
}
