using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Implementations;

namespace QuizMaster.API.Controllers
{
    [Route("api/quizquestions")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class QuizQuestionController : ControllerBase
    {
        private readonly QuizQuestionService _quizQuestionService;
        public QuizQuestionController(QuizQuestionService quizQuestionService)
        {
            _quizQuestionService = quizQuestionService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await _quizQuestionService.GetQuestionsByQuizIdAsync(id);

            return Ok(question);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddQuizQuestion(UserQuizFormRequest userQuizFormRequest)
        {
            var quizquestion = await _quizQuestionService.AddQuizQuestionAsync(userQuizFormRequest);

            return Ok(quizquestion);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateQuizQuestion(int id, UserQuizFormRequest userQuizFormRequest)
        {
            var quizquestion = await _quizQuestionService.UpdateQuizQuestionAsync(id, userQuizFormRequest);

            return Ok(quizquestion);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteQuizQuestion(int id)
        {
            var quizquestion = await _quizQuestionService.DeleteQuizQuestionAsync(id);

            return Ok(quizquestion);
        }
    }
}
