namespace QuizMaster.BusinessLogic.Requests;

public class AnswerOptionRequest
{
    public int Id { get; set; }
    public string OptionText { get; set; }
    public bool IsCorrect { get; set; }
    public int QuestionId { get; set; }
}
