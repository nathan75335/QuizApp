namespace QuizMaster.BusinessLogic.Requests;

public class AnswerOptionRequest
{
    public string OptionText { get; set; }
    public bool IsCorrect { get; set; }
    public int QuestionId { get; set; }
}
