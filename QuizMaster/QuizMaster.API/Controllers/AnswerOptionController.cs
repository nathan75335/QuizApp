using Microsoft.AspNetCore.Mvc;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;

namespace QuizMaster.API.Controllers
{
    [Route("api/answeroptions")]
    [ApiController]
    public class AnswerOptionController : ControllerBase
    {
        private readonly IAnswerOptionService _answerOptionService;
        public AnswerOptionController(IAnswerOptionService answerOptionService)
        {
            _answerOptionService = answerOptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOptions()
        {
            var options = await _answerOptionService.GetAllAnswerOptionsAsync();

            return Ok(options);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOptionsByQuestionId(int id)
        {
            var options = await _answerOptionService.GetOptionsByQuestionIdAsync(id);

            return Ok(options);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAnswerOptions(AnswerOptionRequest answerOptionRequest)
        {
            var option = await _answerOptionService.AddAnswerOptionAsync(answerOptionRequest);

            return Ok(option);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateOptions(int id, AnswerOptionRequest answerOptionRequest)
        {
            var option = await _answerOptionService.UpdateAnswerOption(id, answerOptionRequest);

            return Ok(option);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOption(int id)
        {
            var option = await _answerOptionService.DeleteAnswerOptionAsync(id);

            return Ok(option);
        }
    }
}
