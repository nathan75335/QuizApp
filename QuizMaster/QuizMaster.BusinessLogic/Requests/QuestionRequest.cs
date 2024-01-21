namespace QuizMaster.BusinessLogic.Requests;

public class QuestionRequest
{
    public int Id { get; set; }
    public string Question { get; set; }
    public int Point { get; set; }
    public int QuizId { get; set; }
}
