using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.BusinessLogic.Requests;
//using QuizMaster.BusinessLogic.Services.Implementations;
using QuizMaster.BusinessLogic.Services.Interfaces;

namespace QuizMaster.API.Controllers
{
    [Route("api/quizzes")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var quizzes = await _quizService.GetAllQuizzesAsync();

            return Ok(quizzes);
        }

        [HttpGet("{id:int})")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetQuizById(int id)
        {
            var quiz = await _quizService.GetQuizByIdAsync(id);

            return Ok(quiz);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddQuiz(QuizRequest quizRequest)
        {
            var quiz = await _quizService.AddQuizAsync(quizRequest);

            return Ok(quiz);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateQuiz(int id, QuizRequest quizRequest)
        {
            var quiz = await _quizService.UpdateQuizAsync(id, quizRequest);

            return Ok(quiz);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var quiz = await _quizService.DeleteQuizAsync(id);

            return Ok(quiz);
        }
    }
}
