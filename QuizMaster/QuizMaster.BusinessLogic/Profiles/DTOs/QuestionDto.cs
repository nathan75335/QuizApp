namespace QuizMaster.BusinessLogic.Profiles.DTOs;

public class QuestionDto
{
    public int QuestionId { get; set; }
    public string QuestionTitle { get; set; }
    public int Point { get; set; }
    public int QuizId { get; set; }
    public string QuizTitle { get; set; }
}
