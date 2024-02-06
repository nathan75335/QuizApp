using QuizMaster.BusinessLogic.Requests;

namespace QuizMaster.BusinessLogic.Profiles.DTOs;

public class QuizQuestionDto
{
    //public int QuizId { get; set; }
    public string QuestionText { get; set; }
    public List<AnswerOptionRequest> AnswerOptions { get; set; }
}
