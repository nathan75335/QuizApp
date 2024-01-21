namespace QuizMaster.BusinessLogic.Requests;

public class UserQuizRequest
{
    public int UserQuizId { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public int Score { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}
