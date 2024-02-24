using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;

namespace QuizMaster.API.Controllers
{
    [Route("api/quizquestions")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class QuizQuestionController : ControllerBase
    {
        private readonly IQuizQuestionService _quizQuestionService;
        public QuizQuestionController(IQuizQuestionService quizQuestionService)
        {
            _quizQuestionService = quizQuestionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuizQuestions()
        {
            var question = await _quizQuestionService.GetAllQuizQuestionsAsync();

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
