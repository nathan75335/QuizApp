namespace QuizMaster.BusinessLogic.Profiles.DTOs;

public class AnswerOptionsDto
{
    public int OptionId { get; set; }
    public string OptionText {  get; set; }
    public bool IsCorrect {  get; set; }
    public int QuestionId { get; set; }
    public string QuestionText { get; set; }
}
